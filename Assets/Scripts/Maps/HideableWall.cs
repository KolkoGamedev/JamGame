using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maps
{
    public class HideableWall : MonoBehaviour, IInteractable
    {
        public void Act()
        {
            gameObject.SetActive(false);
        }
    }
}

