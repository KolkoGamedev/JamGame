using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
    public class PlayerUtilities : MonoBehaviour, IShieldable
    {
        public static event Action OnShield = delegate { };
        public static event Action OnUnShield = delegate { };
        public bool IsShielded { get { return shielded; } set { shielded = value; } }
        [SerializeField] private bool shielded = false;

        public void Shield()
        {
            if(!IsShielded)
            {
                IsShielded = true;
                OnShield();
            }
        }

        public void UnShield()
        {
            if(IsShielded)
            {
                IsShielded = false;
                OnUnShield();
            }
        
        }
        private void OnDestroy()
        {
            OnShield = delegate { };
            OnUnShield = delegate { };
        }
    }
}
public interface IShieldable
{
    bool IsShielded { get; set; }
    void Shield();
    void UnShield();

}