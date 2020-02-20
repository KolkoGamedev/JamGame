using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    
    [SerializeField] private float speed = 0.01f;
    private float x;
    private float y;
    private void Awake()
    {
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
    }



    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x * speed, y*speed, 0);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Borders"))
        {
            speed = -speed;
        }
    }
}
