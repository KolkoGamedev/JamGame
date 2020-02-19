using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Medkit : MonoBehaviour
{
    public static event Action<int> OnHealed = delegate { };
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnHealed(1);
            gameObject.SetActive(false);
        }
        
    }
}
