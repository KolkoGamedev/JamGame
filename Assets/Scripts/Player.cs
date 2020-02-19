using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event Action<int> PlayerHit = delegate { };

    public void DealDamage(int value)
    {
        PlayerHit(value);
    }
}
