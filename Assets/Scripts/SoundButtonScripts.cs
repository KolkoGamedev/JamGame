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
    private int counter = 0;

   



    private void Start()
    {
        Button = GetComponent<Button>();
        Button.GetComponent<Image>().sprite = Enabled;

     
    }

    public void ChangeButton()
    {
        counter++;
        if(counter%2 == 1)
        {
            OnMute(); 
            Button.image.overrideSprite = Disabled;
            //muzyka wylaczona
            
        }
        else
        {
            Button.image.overrideSprite = Enabled;
            //muzyka wlaczona
            UnMute();
            
        }
    }

    
}
