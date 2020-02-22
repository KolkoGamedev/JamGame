using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private GameObject Mask = null;
    private Animator playerAnimator;
    private bool isChanged = false;

    private void Awake()
    {
        Portal.OnLevelComplete += ChangeLightSize;
        PlayerHealth.OnDie += ChangeLightSize;
        playerAnimator = Mask.GetComponent<Animator>();
    }

    public void ChangeLightSize()
    {
        isChanged = !isChanged;

        playerAnimator.SetBool("ChangeSize", isChanged);
    }
}
