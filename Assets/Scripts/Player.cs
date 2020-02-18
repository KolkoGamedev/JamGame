using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event Action<Player> OnHit = delegate { };

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hazard"))
        {
            OnHit(this);
            GetComponent<TrailRenderer>().Clear();
        }
    }
    */

}
