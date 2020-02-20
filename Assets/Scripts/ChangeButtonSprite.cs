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

    private void OnMouseOver()
    {
        button = GetComponent<Button>();
        button.GetComponent<Image>().sprite = WhileHoover;
        //button.OnSelect.
    }
}
