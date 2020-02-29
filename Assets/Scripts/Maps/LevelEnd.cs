using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public NeedDoor whatDoorDoINeed = 0;
    public bool isIntercepting = false;
    private MapGenerator mapGen;
    private void Awake()
    {
        mapGen = FindObjectOfType<MapGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MapTile"))
        {
            mapGen.partEnds.Remove(this);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("LevelEnd"))
            isIntercepting = true;
    }
}

public enum NeedDoor
{
    Top = 1,
    Right,
    Bottom,
    Left,
    Random

}