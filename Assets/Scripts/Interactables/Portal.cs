using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Portal : MonoBehaviour
{
    public static event Action OnLevelComplete = delegate { };

    [SerializeField] private string levelToLoad = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OnLevelComplete();
            collision.gameObject.GetComponent<Dissolve>().StartPlayerDissolve();
            Invoke("LoadSceneAfterTime", 2f);
            
        }
    }

    private void LoadSceneAfterTime()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
