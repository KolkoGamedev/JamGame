using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameplayManager : MonoBehaviour
{
    public static event Action PlayerDeath = delegate { };
    [SerializeField] private Transform _spawnPoint = null;
    public int playerHealth = 3;

    private void Awake()
    {
        Player.OnHit += CheckForTeleport;
    }

    private void CheckForTeleport(Player player)
    {
        if (--playerHealth < 0)
            player.transform.position = _spawnPoint.transform.position;
        else
            PlayerDeath();
    }

    
}
