﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int value = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IHealable>().Heal(value);
            gameObject.SetActive(false);
        }
        
    }
}
