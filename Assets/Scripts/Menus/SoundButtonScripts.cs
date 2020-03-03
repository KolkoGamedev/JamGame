using UnityEngine;
using UnityEngine.UI;
using System;

namespace Menus
{
    public class SoundButtonScripts : MonoBehaviour
    {
        public static event Action OnMute = delegate { };
        public static event Action OnUnMute = delegate { };

        [SerializeField] private Button button = null;
        [SerializeField] private Sprite buttonEnabled = null;
        [SerializeField] private Sprite buttonDisabled = null;

        private bool changer = false;

        private void Start()
        {
            button = GetComponent<Button>();
            button.GetComponent<Image>().sprite = buttonEnabled;
        }

        public void ChangeButton()
        {
            if(changer == false)
            {
                OnMute(); 
                button.image.overrideSprite = buttonDisabled;
                changer = true;
            }
            else
            {
                button.image.overrideSprite = buttonEnabled;
                OnUnMute();
                changer = false;
            
            }
        }
    }
}
