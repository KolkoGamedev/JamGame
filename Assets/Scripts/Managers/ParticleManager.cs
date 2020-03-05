using System.Collections;
using System.Collections.Generic;
using Maps;
using Player;
using UnityEngine;

namespace Managers
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private GameObject onHitParticles = null;
        [SerializeField] private GameObject onWallHitStep = null;
        [SerializeField] private GameObject onWallHitFinal = null;
        [SerializeField] private GameObject onDeath = null;

        private void Awake()
        {
            PlayerHealth.OnHit += SpawnOnHitParticles;
            DestroyableWall.OnWallAttack += SpawnOnWallHitStepParticles;
            PlayerHealth.OnDie += SpawnOnDeathParticles;
        }

        private void SpawnOnHitParticles(int v)
        {
            //For optimize, replace singleton with event argument of gameobject player
            var particle = Instantiate(onHitParticles, PlayerMovement.Instance.gameObject.transform.position, Quaternion.identity, null);
        }
        private void SpawnOnWallHitStepParticles(int health, GameObject x)
        {
            if(health != 0)
            {
                var particle = Instantiate(onWallHitStep, PlayerMovement.Instance.gameObject.transform.position, Quaternion.identity, null);
            }
            else
            {
                var particle = Instantiate(onWallHitFinal, x.gameObject.transform.position, Quaternion.identity, null);
            }
        }

        private void SpawnOnDeathParticles(string sceneName)
        {
            var particle = Instantiate(onDeath, PlayerMovement.Instance.gameObject.transform.position, Quaternion.identity, null);
        }

    }
}

