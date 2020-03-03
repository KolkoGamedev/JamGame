using System.Collections.Generic;
using UnityEngine;

namespace Maps
{
    public class Rooms :MonoBehaviour
    {
        [Header("Rooms")] 
        public List<GameObject> top = null;
        public List<GameObject> left = null;
        public List<GameObject> bottom = null;
        public List<GameObject> right = null;
    }
}
