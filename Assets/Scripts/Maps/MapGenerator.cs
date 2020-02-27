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

    private GameObject GetRandomRoomPart(List<GameObject> pool)
    {
        return pool[Random.Range(0, pool.Count)];
    }

    //todo
    private void SpawnMapPart(GameObject part)
    {
        GameObject _spawned = Instantiate(part);
    }

    private Transform GetPartStartingPoint(GameObject part) => part.GetComponentInChildren<LevelStart>().transform;
    //Make list of all endings
    private Transform GetPartEndingPoint(GameObject part)
    {
        for(int i = 0; i < part.transform.childCount; i++)
        {
            //_lastSpawnedEndingPoints.Add();
        }
       return part.GetComponentInChildren<LevelEnd>().transform;
    }

}
