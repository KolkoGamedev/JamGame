using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Maps
{
    public class ClickableButton : MonoBehaviour
    {
        [SerializeField] private GameObject toInteract = null;
        public static event Action OnButtonClick = delegate { };
        private bool isPushed = false;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !isPushed)
            {
                isPushed = true;
                OnButtonClick();
                transform.GetChild(1).transform.localPosition = new Vector3(0, -0.1f, 0);

                if (toInteract != null)
                    toInteract.GetComponent<IInteractable>().Act();
            }
        }
        private void OnDestroy()
        {
            OnButtonClick = delegate { };
        }
    }
}


public interface IInteractable
{    
    void Act();
}