using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Act();
        }    
    }
    public abstract void Act();
}
