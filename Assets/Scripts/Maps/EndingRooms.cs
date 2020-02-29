using System.Collections.Generic;
using UnityEngine;

public class EndingRooms : MonoBehaviour
{
    [Header("Rooms")]
    public List<GameObject> top = null;
    public List<GameObject> right = null;
    public List<GameObject> left = null;
    public List<GameObject> bottom = null;
    
    [Header("Portal rooms")]
    public List<GameObject> portalTop = null;
    public List<GameObject> portalRight = null;
    public List<GameObject> portalLeft = null;
    public List<GameObject> portalBottom = null;
    
}