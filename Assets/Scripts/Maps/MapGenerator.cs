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

    private void Awake()
    {
        if (startingRooms == null)
            Debug.LogWarning("Fill starting rooms before proceeding!");
        else
            SpawnMapPart(GetRandomRoomPart(startingRooms));
            
    }

    private GameObject GetRandomRoomPart(List<GameObject> pool)
    {
        return pool[Random.Range(0, pool.Count)];
    }
    private void SpawnMapPart(GameObject part)
    {
        GameObject _spawned = Instantiate(part);
    }
}
