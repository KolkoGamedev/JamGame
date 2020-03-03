using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement Instance = null;
        public static event Action OnShoot = delegate { };
        public static event Action OnWallHit = delegate { };

        [SerializeField] private float shootPower = 200;
        private Vector3 shootStartingPoint;
        private Vector3 shootEndingPoint;
        private Rigidbody2D rb;
        private Camera mainCam;

        private void Awake()
        {
            Instance = this;
        
            mainCam = Camera.main;
            Visuals.DragIndicator.OnDragFinish += Shoot;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Shoot(Vector3 direction)
        {
            rb.AddForce(direction * shootPower);
            OnShoot();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnWallHit();
        }

        private void OnDestroy()
        {
            OnShoot = delegate { };
            OnWallHit = delegate { };
        }
    }

}
