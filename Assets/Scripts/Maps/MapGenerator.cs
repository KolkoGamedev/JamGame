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

    private List<Transform> _lastSpawnedEndingPoints = null;

    private void Awake()
    {
        SpawnMapPart(GetRandomRoomPart(startingRooms), Vector3.zero);
        GenerateMap();
    }

    private GameObject GetRandomRoomPart(List<GameObject> pool)
    {
        return pool[Random.Range(0, pool.Count)];
    }
    private Vector3 GetRandomEndPointTransform()
    {
        return _lastSpawnedEndingPoints[Random.Range(0, _lastSpawnedEndingPoints.Count)].transform.position;
    }
    private Vector3 GetPartStartingPoint(GameObject part) => part.GetComponentInChildren<LevelStart>().transform.position;
    private void GetPartEndingPoints(GameObject part)
    {
        foreach(Transform x in part.transform)
        {
            _lastSpawnedEndingPoints.Add(x.GetComponent<LevelEnd>().transform);
        }
    }
    private void SpawnMapPart(GameObject part, Vector3 location)
    {
        var spawned = Instantiate(part, location - GetPartStartingPoint(part), Quaternion.identity);
        GetPartEndingPoints(spawned);
    }
    private void GenerateMap()
    {
        for (var i = 0; i < roomCount; i++)
        {
            SpawnMapPart(GetRandomRoomPart(rooms), GetRandomEndPointTransform());
        }
        SpawnMapPart(GetRandomRoomPart(endRooms), GetRandomEndPointTransform());
    }


}
