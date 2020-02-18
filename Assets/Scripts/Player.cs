using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event Action<Player> PlayerHit = delegate { };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hazard"))
        {
            PlayerHit(this);
            GetComponent<TrailRenderer>().Clear();
        }
    }
}
