using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.ScriptableEvents
{
    [CreateAssetMenu(fileName = "Scriptable Event", menuName = "ScriptableEvents/WrapEvent", order = 0)]
    public class ScriptableEventWrap : ScriptableObject
    {
        private event Action _event;

        public void Register(Action onEvent)
        {
            _event += onEvent;
        }

        public void UnRegister(Action onEvent)
        {
            _event -= onEvent;
        }

        public void Wrap()
        {
            _event?.Invoke();
        }

    }
}