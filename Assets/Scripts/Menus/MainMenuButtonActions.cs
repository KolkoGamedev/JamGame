using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class MainMenuButtonActions : MonoBehaviour
    {
        [SerializeField] private string levelName = null;
        public void PlayGame()
        {
            SceneManager.LoadScene(levelName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }

}
