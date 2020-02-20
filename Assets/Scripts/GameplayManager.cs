using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private Transform PlayerLight = null;

    private void Awake()
    {
        BlackHole.OnTeleport += TeleportToSpawn;
        Portal.OnLevelComplete += ChangeLightSize;
    }

    private void TeleportToSpawn(GameObject player)
    { 
        player.gameObject.transform.position = _spawnPoint.transform.position;
        player.GetComponent<TrailRenderer>().Clear();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void ChangeLightSize(GameObject player)
    {
        player.GetComponent<PlayerUtilities>().ChangeMaskSize();
    }
}
