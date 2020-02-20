using UnityEngine;
using UnityEngine.UI;

public class SoundButtonScripts : MonoBehaviour
{
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
            Button.image.overrideSprite = Disabled;
        }
        else
        {
            Button.image.overrideSprite = Enabled;
        }
    }
}
