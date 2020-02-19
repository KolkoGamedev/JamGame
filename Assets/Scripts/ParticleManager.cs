using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject OnHitParticles = null;

    private void Awake()
    {
        PlayerHealth.OnHit += SpawnOnHitParticles;
    }

    private void SpawnOnHitParticles(int v)
    {
        GameObject particle = Instantiate(OnHitParticles, PlayerMovement.Instance.gameObject.transform.position, Quaternion.identity, null);
    }

}
