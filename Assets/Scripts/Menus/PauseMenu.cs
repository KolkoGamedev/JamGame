using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu = null;
        [SerializeField] private GameObject quitQuestion = null;
        [SerializeField] private Button ContinueButton = null;
        [SerializeField] private Button MainMenuButton = null;
        [SerializeField] private Button QuitGameButton = null;
        [SerializeField] private Button YesButton = null;
        [SerializeField] private Button NoButton = null;
        private bool isPaused = false;




        void Start()
        {
            ContinueButton.onClick.AddListener(Resume);
            MainMenuButton.onClick.AddListener(SceneChange);
            QuitGameButton.onClick.AddListener(QuitQuestion);
            YesButton.onClick.AddListener(Quit);
            NoButton.onClick.AddListener(Pause);
        }



        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            quitQuestion.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }

        public void Pause()
        {
            pauseMenu.SetActive(true);
            quitQuestion.SetActive(false);
            Time.timeScale = 0;
            isPaused = true;
        }

        public void QuitQuestion()
        {
            pauseMenu.SetActive(false);
            quitQuestion.SetActive(true);
        }

        public void SceneChange()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Quit()
        {
            Application.Quit();
        }

    }

}
