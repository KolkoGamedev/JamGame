﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class TutorialTip : MonoBehaviour
    {
        public string tip = null;
        private Tutorial tut;

  
        private void Awake()
        {
            tut = FindObjectOfType<Tutorial>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                tut.enteredTrigger = true;
                tut.SetText(tip);
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                tut.enteredTrigger = false;
                Invoke(nameof(TimedClearText), 2.5f);
            }
              
        }

        private void TimedClearText()
        {
            if(!tut.enteredTrigger)
                tut.ClearText();
        }
    }

}
