using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Maps
{
    public class DestroyableWall : MonoBehaviour
    {
        [SerializeField] private int wallLifes = 3;
        [SerializeField] private List<Sprite> sprites = null;

        public static event Action<int, GameObject> OnWallAttack = delegate { };
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
            return sprites[wallLifes];
        }

        private void Damaged()
        {
            wallLifes--;
            OnWallAttack(wallLifes, gameObject);
            if(wallLifes == 0)
            {
                gameObject.SetActive(false);
            }
        }

    }
}

