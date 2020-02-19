using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint = null;

    private void Awake()
    {
        Teleporter.OnTeleport += TeleportToSpawn;
    }

    private void TeleportToSpawn(GameObject player)
    {
        player.gameObject.transform.position = _spawnPoint.transform.position;
        player.GetComponent<TrailRenderer>().Clear();
    }
}
