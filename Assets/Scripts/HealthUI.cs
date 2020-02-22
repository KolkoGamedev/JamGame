using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        PlayerHealth.OnHit += RemoveHeart;
        PlayerHealth.OnHeal += AddHeart;
        PlayerUtilities.OnShield += ShieldHeart;
        PlayerUtilities.OnUnShield += UnshieldHeart;
    }

    private void RemoveHeart(int value)
    {
        if(heartIndex >= 0)
        for(int i = 0; i < value; i++)
        {
            HeartImgs[heartIndex--].gameObject.SetActive(false);
        }
    }
    private void AddHeart(int value)
    {
        if(heartIndex < 3)
        {
            for(int i = 0; i < value; i++)
            {
                HeartImgs[heartIndex + 1].gameObject.SetActive(true);
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
