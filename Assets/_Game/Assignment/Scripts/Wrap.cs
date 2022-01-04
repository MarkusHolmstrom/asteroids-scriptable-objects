using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

namespace WrappingObstacles
{
    [CreateAssetMenu(fileName = "Wrap", menuName = "ScriptableObjects/Wrap", order = 0)]
    public class Wrap : ScriptableObject
    {
        public bool haveScreenAsLimit = false;

        public float xLimit;

        public float yLimit;

    }

}
