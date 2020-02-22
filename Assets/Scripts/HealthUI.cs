using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Sprite shieldedHeart;
    private Image[] HeartImgs = null;

    int heartAmount;

    private void Awake()
    {
        HeartImgs = GetComponentsInChildren<Image>();
        heartAmount = HeartImgs.Length-1;

        PlayerHealth.OnHit += RemoveHeart;
        PlayerUtilities.OnShield += ShieldHeart;
    }

    private void RemoveHeart(int value)
    {
        for(int i = 0; i < value; i++)
        {
            HeartImgs[heartAmount--].gameObject.SetActive(false);
        }
    }
    private void ShieldHeart()
    {
        HeartImgs[heartAmount].sprite = shieldedHeart;
    }
}
