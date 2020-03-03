using System.Collections.Generic;
using UnityEngine;

namespace Maps
{
    public class BossRooms : MonoBehaviour
    {
        [Header("Boss Rooms")] 
        public List<GameObject> top = null;
        public  List<GameObject> bottom = null;
        public  List<GameObject> left = null;
        public  List<GameObject> right = null;
    }
}
