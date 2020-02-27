using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Map Parts")]
    [SerializeField] private List<GameObject> startingRooms = null;
    [SerializeField] private List<GameObject> rooms = null;
    [SerializeField] private List<GameObject> connectors = null;
    [SerializeField] private List<GameObject> bossRooms = null;
    [SerializeField] private List<GameObject> endRooms = null;
    [Space]
    [SerializeField] private int roomCount = 2;

    private List<Transform> _lastSpawnedEndingPoints;

    private void Awake()
    {
        //_lastSpawnedEndingPoints.Add();
        SpawnMapPart(startingRooms);
    }

    private GameObject GetRandomRoomPart(List<GameObject> pool)
    {
        return pool[Random.Range(0, pool.Count)];
    }
    private Transform GetRandomEndPointTransform()
    {
        return _lastSpawnedEndingPoints[Random.Range(0, _lastSpawnedEndingPoints.Count)];
    }
    //todo
    private void SpawnMapPart(List<GameObject> part)
    {
        GameObject _spawned = Instantiate(GetRandomRoomPart(part), GetRandomEndPointTransform().position, Quaternion.identity);
    }

    private Transform GetPartStartingPoint(GameObject part) => part.GetComponentInChildren<LevelStart>().transform;
    //Make list of all endings
    private void GetPartEndingPoints(GameObject part)
    {
        //Can try to change it to for, but will be less clean
        foreach(GameObject x in part.transform)
        {
            _lastSpawnedEndingPoints.Add(x.GetComponent<LevelEnd>().transform);
        }
    }

}
