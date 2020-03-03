﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class LightManager : MonoBehaviour
    {
        [SerializeField] private int startingScale = 5;
        private void Start()
        {
            Visuals.DragIndicator.OnDragFinish += StartChangingSize;
            PlayerMovement.OnWallHit += GoBack;
        }
        private void StartChangingSize(Vector3 power)
        {
            var x = startingScale + power.magnitude;
            gameObject.transform.DOScale(new Vector3(x, x, x), .5f);
        }

        private void GoBack()
        {
            gameObject.transform.DOScale(new Vector3(5f, 5f, 5f), .5f);
        }
    }
}

