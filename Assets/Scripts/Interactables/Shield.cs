using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IShieldable>().Shield();
            gameObject.SetActive(false);
        }

    }
}
