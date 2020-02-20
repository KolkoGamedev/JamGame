using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWallDestroy : MonoBehaviour
{
    [SerializeField] private int WallLifes = 4;
    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;
    public void Start()
    {
        
    }
    public void OnAttackByPlayer()
    {
        WallLifes--;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision");
            OnAttackByPlayer();
        }
    }
    public void Update()
    {
        if (WallLifes == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spr2;
        }
        else if(WallLifes == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spr1;
        }

        else if (WallLifes == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spr3;
        }
        else if (WallLifes == 0)
        {
            Destroy(gameObject);
        }
    }

}
