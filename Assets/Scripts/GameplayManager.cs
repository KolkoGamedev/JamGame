using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private GameObject AudioManagerPrefab = null;

    private void Start()
    {
        BlackHole.OnTeleport += TeleportToSpawn;
        if (FindObjectOfType<AudioManager>() == null)
        {
            Instantiate(AudioManagerPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    private void TeleportToSpawn(GameObject player)
    { 
        player.gameObject.transform.position = _spawnPoint.transform.position;
        player.GetComponent<TrailRenderer>().Clear();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }


}
