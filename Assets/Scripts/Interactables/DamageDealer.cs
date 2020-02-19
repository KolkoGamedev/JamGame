using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int Damage = 1;
    [SerializeField] private int PushbackForce = 300;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IDamagable>().TakeDamage(Damage);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1f), 1f) * PushbackForce);
            
        }
    }
}
