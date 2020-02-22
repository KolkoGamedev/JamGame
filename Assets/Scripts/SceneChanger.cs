using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Awake()
    {
        PlayerHealth.OnDie += InvokeLoseScreen;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level1");
    }

    public void InvokeLoseScreen()
    {
        Invoke("LoadLoseScreen", 1f);
    }
    private void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    
}
