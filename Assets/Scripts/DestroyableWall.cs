using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyableWall : MonoBehaviour
{
    [SerializeField] private int WallLifes = 3;
    [SerializeField] private List<Sprite> Sprites = null;

    public static event Action OnWallAttack = delegate { };
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damaged();
            sr.sprite = Hit();
        }
    }
    private Sprite Hit()
    {
        return Sprites[Sprites.Count - WallLifes];
    }

    private void Damaged()
    {
        WallLifes--;
        OnWallAttack();
        if(WallLifes == 0)
        {
            gameObject.SetActive(false);
        }
    }

}
