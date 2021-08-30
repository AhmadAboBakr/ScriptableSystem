using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableSystem
{
    [System.Serializable]
    public struct ScriptableEventAndUnityEventPair
    {
        public UnityEvent unityEvent;
        public ScriptableEvent scriptableEvent;
        public void OnInvoke()
        {
            unityEvent.Invoke();
        }
    }
    public class EventListner : MonoBehaviour
    {
        [HideInInspector][SerializeField] private List<ScriptableEventAndUnityEventPair> events;
        private void OnEnable()
        {
            foreach (var @event in events)
            {
                @event.scriptableEvent?.Subscribe(@event.OnInvoke);
            }
        }
        private void OnDisable()
        {
            foreach (var @event in events)
            {
                @event.scriptableEvent?.Unsubscribe(@event.OnInvoke);
            }

        }
    }
}
