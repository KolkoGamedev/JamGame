using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundButtonScripts : MonoBehaviour
{
    public static event Action OnMute = delegate { };
    public static event Action UnMute = delegate { };

    public Button Button;
    public Sprite Enabled;
    public Sprite Disabled;

    private bool changer = false;

    private void Start()
    {
        Button = GetComponent<Button>();
        Button.GetComponent<Image>().sprite = Enabled;
    }

    public void ChangeButton()
    {
        if(changer == false)
        {
            OnMute(); 
            Button.image.overrideSprite = Disabled;
            changer = true;
            //muzyka wylaczona
            
        }
        else
        {
            Button.image.overrideSprite = Enabled;
            //muzyka wlaczona
            UnMute();
            changer = false;
            
        }
    }

    
}
