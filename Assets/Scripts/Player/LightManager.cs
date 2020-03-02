using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private GameObject mask = null;
    [SerializeField] private int startingScale = 5;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        PlayerMovement.OnShoot += StartChangingSize;
    }
    private void StartChangingSize()
    {
        float x = startingScale + rb.velocity.magnitude;
        mask.transform.DOScale(new Vector3(x, x, x), .5f);
    }

    private void GoBack()
    {
        mask.transform.DOScale(new Vector3(5f, 5f, 5f), 3f);
    }
}
