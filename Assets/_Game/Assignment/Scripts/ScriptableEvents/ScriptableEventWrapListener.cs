using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.ScriptableEvents
{
    public class ScriptableEventWrapListener : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEventWrap _event;
        [SerializeField]
        private UnityEvent _response;
        private void OnEventWrap()
        {
            _response.Invoke();
        }

        private void OnEnable()
        {
            _event.Register(OnEventWrap);
        }

        private void OnDisable()
        {
            _event.UnRegister(OnEventWrap);
        }

    }
}
