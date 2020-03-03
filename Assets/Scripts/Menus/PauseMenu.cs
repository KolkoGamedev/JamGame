using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu = null;
        [SerializeField] private GameObject quitQuestion = null;
        private bool isPaused = false;

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

    }

}
