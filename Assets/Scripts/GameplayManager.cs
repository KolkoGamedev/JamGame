using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint = null;
    public static GameplayManager GetInstance { get; private set; }
    public int playerHealth = 3;

    private void Awake()
    {

        if (!GetInstance)
            GetInstance = this;
        else
            Destroy(gameObject);

        Player.PlayerHit += ChangeHealth;
        Medkit.OnHealed += ChangeHealth;
        Teleporter.OnTeleport += TeleportToSpawn;

    }

    private void TeleportToSpawn(GameObject player)
    {
        player.gameObject.transform.position = _spawnPoint.transform.position;
        player.GetComponent<TrailRenderer>().Clear();
    }

    private void ChangeHealth(int value)
    {
        playerHealth += value;
        if (playerHealth < 0)
        {
            //death
        }
    }


}
