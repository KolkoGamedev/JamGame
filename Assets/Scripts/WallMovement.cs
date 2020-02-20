using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    
    [SerializeField] private float speed = 100f;
    
    private void Awake()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 movement = gameObject.transform.rotation * Vector3.up;
        transform.position += movement * speed*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Borders"))
        {
            speed = -speed;
        }
    }
}
