using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideableWall : MonoBehaviour, IInteractable
{
    public void Act()
    {
        gameObject.SetActive(false);
    }
}
