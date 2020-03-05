using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSlider : MonoBehaviour
{
    [SerializeField] private int x=1;
    [SerializeField] private Slider slider;
    
    
    public void Update()
    {
        if (slider.value != 1)
        {
            slider.value += Time.deltaTime / x;

        }
        if (slider.value == 1)
        {
            slider.gameObject.SetActive(false);
        }
    }
}
