using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float shootPower = 200;
    private Vector3 _shootStartingPoint;
    private Vector3 _shootEndingPoint;
    private Rigidbody2D rb;
    private Camera _mainCam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _mainCam = Camera.main;
    }

    private void Start()
    {
        DragIndicator.OnDragFinish += Shoot;
    }

    private void Shoot(Vector3 direction)
    {
        rb.AddForce(direction * shootPower);
    }

    
}
