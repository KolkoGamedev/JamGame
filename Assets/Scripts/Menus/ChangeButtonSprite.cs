using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class ChangeButtonSprite : MonoBehaviour
    {
        public Button button;
        public Sprite beforeHover;
        public Sprite whileHover;

        private void Start()
        {
            button = GetComponent<Button>();
            button.GetComponent<Image>().sprite = beforeHover;
        }

        public void ChangeToDefaultSprite()
        {
            button.image.overrideSprite = beforeHover;
        }

        public void ChangeToBrokenSprite()
        {
            button.image.overrideSprite = whileHover;
        }
    }
}
