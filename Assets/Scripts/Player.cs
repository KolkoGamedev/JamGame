using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event Action OnDeath = delegate { };
    public static event Action OnHit = delegate { };

    private int _health = 3;

    public void PlayerHit()
    {
        if (--_health < 0)
            OnDeath();
        else
            OnHit();
    }
}
