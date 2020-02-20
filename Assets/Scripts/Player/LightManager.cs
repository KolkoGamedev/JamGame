using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private GameObject Mask = null;
    private Animator playerAnimator;

    private void Awake()
    {
        Portal.OnLevelComplete += ChangeLightSize;
        playerAnimator = Mask.GetComponent<Animator>();
    }

    public void ChangeLightSize()
    {
        playerAnimator.SetBool("ChangeSize", true);
    }
}
