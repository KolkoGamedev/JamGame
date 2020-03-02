using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float smoothSpeed = .3f;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private Vector3 refPos = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 desPos = target.position + offset;
        refPos *= Time.smoothDeltaTime;
        transform.position = Vector3.SmoothDamp(transform.position, desPos, ref refPos, smoothSpeed);   
    }
}
