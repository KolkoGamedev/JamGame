using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporter : MonoBehaviour
{
    public static event Action<GameObject> OnTeleport = delegate { };
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnTeleport(collision.gameObject);
        }
    }
}
