using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu = null;
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

        private void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }

        private void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

}
