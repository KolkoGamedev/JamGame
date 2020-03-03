using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Interactables
{
    public class Portal : MonoBehaviour
    {
        public static event Action OnLevelComplete = delegate { };
        [SerializeField] private bool isFinish = false;
        [SerializeField] private string levelToLoad = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                if(!isFinish)
                {
                    OnLevelComplete();
                    collision.gameObject.GetComponent<Dissolve>().StartPlayerDissolve();
                    Invoke(nameof(LoadSceneAfterTime), 2f);
                }
                else
                {
                    collision.gameObject.GetComponent<Dissolve>().StartPlayerDissolve();
                    Invoke(nameof(LoadSceneAfterTime), 2f);
                }
            
            }
        }

        private void LoadSceneAfterTime()
        {
            SceneManager.LoadScene(levelToLoad);
        }

        private void OnDestroy()
        {
            OnLevelComplete = delegate { };
        }
    }

}
