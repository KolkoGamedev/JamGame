using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject OnHitParticles = null;

    private void Awake()
    {
        PlayerHealth.OnHit += SpawnOnHitParticles;
        //DestroyableWall.OnWallAttack += SpawnDestroyableWallParticles;
    }

    private void SpawnOnHitParticles(int v)
    {
        //For optimize, replace singleton with event argument of gameobject player
        GameObject particle = Instantiate(OnHitParticles, PlayerMovement.Instance.gameObject.transform.position, Quaternion.identity, null);
    }
}
