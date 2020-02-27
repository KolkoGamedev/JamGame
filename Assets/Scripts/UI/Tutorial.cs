using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    private TMP_Text Text = null;
    public bool enteredTrigger = false;

    private void Awake()
    {
        Text = GetComponent<TMP_Text>();
    }

    public void SetText(string txt)
    {
        Text.text = txt;
    }

    public void ClearText()
    {
        Text.text = "";
    }
}
