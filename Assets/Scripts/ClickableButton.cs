using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickableButton : MonoBehaviour
{
    [SerializeField] private GameObject ToInteract;
    public static event Action OnButtonClick = delegate { };

    private bool isPushed = false;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPushed)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isPushed = true;
                OnButtonClick();

                transform.localPosition = new Vector3(0, -0.1f, 0);

                if (ToInteract != null)
                ToInteract.GetComponent<IInteractable>().Act();
            }
        }

    }
}

public interface IInteractable
{
    void Act();
}