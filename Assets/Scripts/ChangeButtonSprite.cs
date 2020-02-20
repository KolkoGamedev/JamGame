using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSprite : MonoBehaviour
{
    public Button button;
    public Sprite BeforeHoover;
    public Sprite WhileHoover;

    private void Start()
    {
        button = GetComponent<Button>();
        button.GetComponent<Image>().sprite = BeforeHoover;
    }

    public void ChangeToDefaultSprite()
    {
        button.image.overrideSprite = BeforeHoover;
    }

    public void ChangeToBrokenSprite()
    {
        button.image.overrideSprite = WhileHoover;
    }
}