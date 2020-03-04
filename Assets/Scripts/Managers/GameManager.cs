using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Player.PlayerHealth.OnDie += InvokeLoseScreen;
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    // Brakuje funkcji, która będzie robić retry poziomu, który zjebaliśmy

    public void InvokeLoseScreen()
    {
        Invoke(nameof(LoadLoseScreen), 1.5f);
    }
    private void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
