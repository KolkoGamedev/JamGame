using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject OnHitParticles = null;
    [SerializeField] private GameObject OnWallHitStep = null;
    [SerializeField] private GameObject OnWallHitFinal = null;
    [SerializeField] private GameObject OnDeath = null;

    private void Awake()
    {
        PlayerHealth.OnHit += SpawnOnHitParticles;
        DestroyableWall.OnWallAttack += SpawnOnWallHitStepParticles;
        PlayerHealth.OnDie += SpawnOnDeathParticles;
    }

    private void SpawnOnHitParticles(int v)
    {
        //For optimize, replace singleton with event argument of gameobject player
        GameObject particle = Instantiate(OnHitParticles, PlayerMovement.Instance.gameObject.transform.position, Quaternion.identity, null);
    }
    private void SpawnOnWallHitStepParticles(int health, GameObject x)
    {
        if(health != 0)
        {
            GameObject particle = Instantiate(OnWallHitStep, PlayerMovement.Instance.gameObject.transform.position, Quaternion.identity, null);
        }
        else
        {
            GameObject particle = Instantiate(OnWallHitFinal, x.gameObject.transform.position, Quaternion.identity, null);
        }
    }

    private void SpawnOnDeathParticles()
    {
        GameObject particle = Instantiate(OnDeath, PlayerMovement.Instance.gameObject.transform.position, Quaternion.identity, null);
    }

}
