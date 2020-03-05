using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LooseScreenButtonsActions : MonoBehaviour
{
    [SerializeField] private Button retryButton = null;
    [SerializeField] private Button menuButton = null;

    private void Awake()
    {
        retryButton.onClick.AddListener(RetryButtonOnClick);
        menuButton.onClick.AddListener(MenuButtonOnClick);
    }
    
    private void RetryButtonOnClick()
    {
        SceneManager.LoadScene(GameManager.Instance.playerDeathLevel);
    }

    private void MenuButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
