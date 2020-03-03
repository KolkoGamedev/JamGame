using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Managers
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private GameObject audioManagerPrefab = null;

        private void Start()
        {
            Interactables.BlackHole.OnTeleport += TeleportToSpawn;
            if (FindObjectOfType<AudioManager>() == null)
            {
                Instantiate(audioManagerPrefab, Vector3.zero, Quaternion.identity);
            }
        }

        private void TeleportToSpawn(GameObject player)
        { 
            player.gameObject.transform.position = spawnPoint.transform.position;
            player.GetComponent<TrailRenderer>().Clear();
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}

