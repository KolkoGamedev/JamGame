using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Interactables
{
    public class BlackHole : MonoBehaviour
    {
        public static event Action<GameObject> OnTeleport = delegate { };
        private Dissolve playerDissolve;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (!playerDissolve)
                {
                    playerDissolve = collision.gameObject.GetComponent<Dissolve>();
                }

                playerDissolve.StartPlayerDissolve();
                StartCoroutine(InvokeTeleport(collision.gameObject, 1f));
            }
        }

        private IEnumerator InvokeTeleport(GameObject go, float time)
        {
            yield return new WaitForSeconds(time);
            OnTeleport?.Invoke(go);
            playerDissolve.StartPlayerReverseDissolve(go);
        }

        private void OnDestroy()
        {
            OnTeleport = delegate { };
        }
    }

}

