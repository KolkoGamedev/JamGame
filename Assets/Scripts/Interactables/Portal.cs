using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Portal : MonoBehaviour
{
    public static event Action<GameObject> OnLevelComplete = delegate { };

    [SerializeField] private string levelToLoad = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OnLevelComplete(collision.gameObject);
            collision.gameObject.GetComponent<Dissolve>().StartPlayerDissolve();

            //SceneManager.LoadScene(levelToLoad);
        }
    }
}
