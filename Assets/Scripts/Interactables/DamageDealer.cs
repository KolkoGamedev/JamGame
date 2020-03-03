using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private int pushbackForce = 300;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Player.IDamagable>().TakeDamage(damage);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1f), 1f) * pushbackForce);
            
            }
        }
    }
}

