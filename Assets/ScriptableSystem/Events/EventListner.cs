using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableSystem
{
    [System.Serializable]
    public class ScriptableEventAndUnityEventPair
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
        [HideInInspector] [SerializeField] private List<ScriptableEventAndUnityEventPair> events;
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

    [System.Serializable]
    public class ScriptableEventAndUnityEventPair<T>
    {
        public UnityEvent<T> unityEvent;
        public ScriptableEvent<T> scriptableEvent;
        public void OnInvoke(T data)
        {
            unityEvent.Invoke(data);
        }
    }

    public class EventListner<T> : MonoBehaviour
    {
        [HideInInspector] [SerializeField] private List<ScriptableEventAndUnityEventPair<T>> events;
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

