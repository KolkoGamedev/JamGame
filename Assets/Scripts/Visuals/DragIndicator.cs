using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player.Visuals
{
    public class DragIndicator : MonoBehaviour
    {
        public static event Action<Vector3> OnDragFinish = delegate { };

        private Camera _mainCam;
        private LineRenderer _lr;
        private Vector3 _startPositon;
        private Vector3 _endPosition;
        private Vector3 _camOffset = new Vector3(0, 0, 10);

        private void Awake()
        {
            _lr = GetComponent<LineRenderer>();
            _mainCam = Camera.main;
            _lr.positionCount = 2;
            _lr.useWorldSpace = true;
            _lr.numCapVertices = 10;
            _lr.enabled = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _lr.enabled = true;
                _startPositon = _mainCam.ScreenToWorldPoint(Input.mousePosition) + _camOffset;
                _lr.SetPosition(0, _startPositon);
            }
        
            if(Input.GetMouseButton(0))
            {
            
                _endPosition = _mainCam.ScreenToWorldPoint(Input.mousePosition) + _camOffset;
                _lr.SetPosition(1, _endPosition);
            }
        
            if(Input.GetMouseButtonUp(0))
            {
                _lr.enabled = false;

                OnDragFinish((_startPositon - _endPosition));
            }
        }

        private void OnDestroy()
        {
            OnDragFinish = delegate { };
        }
    }

}
