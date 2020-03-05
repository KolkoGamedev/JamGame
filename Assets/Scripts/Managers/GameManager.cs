using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string playerDeathLevel = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        Player.PlayerHealth.OnDie += DeathScreen;
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void DeathScreen(string sceneName)
    {
        playerDeathLevel = sceneName;
        SceneManager.LoadScene("LoseScreen");
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(playerDeathLevel);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
