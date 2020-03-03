using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneChanger : MonoBehaviour
    {
        //change to gamemanager
        private void Awake()
        {
            Player.PlayerHealth.OnDie += InvokeLoseScreen;
        }
        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Retry()
        {
            SceneManager.LoadScene("Tutorial");
        }

        public void InvokeLoseScreen()
        {
            Invoke(nameof(LoadLoseScreen), 1.5f);
        }
        private void LoadLoseScreen()
        {
            SceneManager.LoadScene("LoseScreen");
        }
    
    }
}

