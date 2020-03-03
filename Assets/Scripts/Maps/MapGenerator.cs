using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Maps.Rooms))]
[RequireComponent(typeof(Maps.EndingRooms))]
public partial class MapGenerator : MonoBehaviour
{
    [SerializeField] private int roomCount = 2;
    [SerializeField] private bool shouldMapHaveBoss = false;
    
    public List<Maps.LevelEnd> partEnds = new List<Maps.LevelEnd>();
    
    private int portalCount = 1;
    private Maps.Rooms rooms = null;
    private Maps.BossRooms bossRooms = null;
    private Maps.EndingRooms endingRooms = null;
    private void Awake()
    {
        if (shouldMapHaveBoss)
            bossRooms = GetComponent<Maps.BossRooms>();
        
        rooms = GetComponent<Maps.Rooms>();
        endingRooms = GetComponent<Maps.EndingRooms>();
        
        //Get Ending Portal count
        portalCount += GetPortalCount();
    }

    private void Start()
    {
       SpawnMapPart(GetRandomMapPart(NeedDoor.Random), Vector3.zero);
       StartCoroutine(GenerateMap());
    }

    private IEnumerator GenerateMap()
    {
        for (var i = 0; i < roomCount; i++)
        {
            var rolledPartEnd = RandomOf(partEnds);
            SpawnMapPart(GetRandomMapPart(rolledPartEnd.whatDoorDoINeed), rolledPartEnd.transform.position);
            yield return new WaitForSeconds(.2f);
        }
        StartCoroutine(GenerateMapEndings());
    }

    private IEnumerator GenerateMapEndings()
    {
        if (!shouldMapHaveBoss)
        {
            for (var i = 0; i < portalCount; i++)
            {
                var rolledPartEnd = RandomOf(partEnds);
                SpawnMapPart(GetRandomMapPart(rolledPartEnd.whatDoorDoINeed, true, true), rolledPartEnd.transform.position);
                yield return new WaitForSeconds(.2f);
            }
            
            while(partEnds.Count > 0)
            {
                var rolledPartEnd = RandomOf(partEnds);
                SpawnMapPart(GetRandomMapPart(rolledPartEnd.whatDoorDoINeed, true, false), rolledPartEnd.transform.position);
                yield return new WaitForSeconds(.2f);
            }
        }
        //if boss exists
    }
    private void SpawnMapPart(GameObject part, Vector3 location)
    {
        var spawned = Instantiate(part, location, Quaternion.identity, transform);
        
        GetPartSpawnPoints(spawned);
    }
    private GameObject GetRandomMapPart(NeedDoor doorNeeded)
    {
        switch (doorNeeded)
        {
            case NeedDoor.Top:
                return RandomOf(rooms.top);
            case NeedDoor.Right:
                return RandomOf(rooms.right);
            case NeedDoor.Bottom:
                return RandomOf(rooms.bottom);
            case NeedDoor.Left:
                return RandomOf(rooms.left);
            case NeedDoor.Random:
            {
                var rnd = Random.Range(0, 4);
                switch (rnd)
                {
                    case 3:
                        return RandomOf(rooms.right);
                    case 2:
                        return RandomOf(rooms.bottom);
                    case 1:
                        return RandomOf(rooms.left);
                    case 0:
                        return RandomOf(rooms.top);
                    default:
                        return null;
                }
            }
            default:
                return null;
        }
    }
    private GameObject GetRandomMapPart(NeedDoor doorNeeded, bool isEnding, bool isPortal)
    {
        if (endingRooms && !isPortal)
            switch (doorNeeded)
            {
                case NeedDoor.Top:
                    return RandomOf(endingRooms.top);
                case NeedDoor.Right:
                    return RandomOf(endingRooms.right);
                case NeedDoor.Bottom:
                    return RandomOf(endingRooms.bottom);
                case NeedDoor.Left:
                    return RandomOf(endingRooms.left);
                case NeedDoor.Random:
                    return null;
                default:
                    return null;
            }
        else if (endingRooms && isPortal)
        {
            switch (doorNeeded)
            {
                case NeedDoor.Top:
                    return RandomOf(endingRooms.portalTop);
                case NeedDoor.Right:
                    return RandomOf(endingRooms.portalRight);
                case NeedDoor.Bottom:
                    return RandomOf(endingRooms.portalBottom);
                case NeedDoor.Left:
                    return RandomOf(endingRooms.portalLeft);
                case NeedDoor.Random:
                    return null;
                default:
                    return null;
            }
        }
        else return null;
    }
    private void GetPartSpawnPoints(GameObject spawned)
    {
        for (var i = 0; i < spawned.transform.childCount; i++)
        {
            if (!spawned.transform.GetChild(i).GetComponent<Maps.LevelEnd>()) continue;
            partEnds.Add(spawned.transform.GetChild(i).GetComponent<Maps.LevelEnd>());
            
        }
    }
    private GameObject RandomOf(List<GameObject> list) => list[Random.Range(0, list.Count)];
    private Maps.LevelEnd RandomOf(List<Maps.LevelEnd> list) => list[Random.Range(0, list.Count)];
    private int GetPortalCount()
    {
        var counter = 0;
        var temp = roomCount;
        for (var i = 0; i < temp; i++)
        {
            if (temp < 5) return counter; 
            counter++;
            temp -= 5;

        }
        return counter;
    }
}
    
