using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerUtilities : MonoBehaviour, IShieldable
{
    public static event Action OnShield = delegate { };
    public static event Action OnUnShield = delegate { };
    public bool isShielded { get { return shielded; } set { shielded = value; } }
    [SerializeField] private bool shielded = false;

    public void Shield()
    {
        if(!isShielded)
        {
            isShielded = true;
            OnShield();
        }
    }

    public void UnShield()
    {
        if(isShielded)
        {
            isShielded = false;
            OnUnShield();
        }
        
    }
    private void OnDestroy()
    {
        OnShield = delegate { };
        OnUnShield = delegate { };
    }
}


public interface IShieldable
{
    bool isShielded { get; set; }
    void Shield();
    void UnShield();

}