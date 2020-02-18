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

        Player.PlayerHit += TeleportToSpawn;
    }

    private void TeleportToSpawn(Player player)
    {
        if (--playerHealth > 0)
            player.gameObject.transform.position = _spawnPoint.transform.position;
        //else
            //PlayerDeath();
    }
}
