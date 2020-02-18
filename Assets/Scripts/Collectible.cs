using UnityEngine;
using System;

public abstract class Collectible : MonoBehaviour
{
    public CollectibleType collectibleType = 0;

}

public enum CollectibleType
{
    Medkit,
    Shield
}
