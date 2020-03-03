using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Sprite shieldedHeart = null;
        [SerializeField] private Sprite unshieldedHeart = null;

        private Image[] HeartImgs = null;
        private int heartIndex;

        private void Awake()
        {
            HeartImgs = GetComponentsInChildren<Image>();
            heartIndex = HeartImgs.Length-1;

            Player.PlayerHealth.OnHit += RemoveHeart;
            Player.PlayerHealth.OnHeal += AddHeart;
            Player.PlayerUtilities.OnShield += ShieldHeart;
            Player.PlayerUtilities.OnUnShield += UnshieldHeart;
        }

        private void RemoveHeart(int value)
        {
            if(heartIndex >= 0)
                for(var i = 0; i < value; i++)
                {
                    HeartImgs[heartIndex--].gameObject.SetActive(false);
                }
        }

        private void AddHeart(int value)
        {
            if(heartIndex < 3)
            {
                for(var i = 0; i < value; i++)
                {
                    HeartImgs[heartIndex+1].gameObject.SetActive(true);
                }
            }
        }

        private void ShieldHeart()
        {
            HeartImgs[heartIndex].sprite = shieldedHeart;
        }

        private void UnshieldHeart()
        {
            HeartImgs[heartIndex].sprite = unshieldedHeart;
        }
    }

}
