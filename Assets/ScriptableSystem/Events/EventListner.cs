using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableSystem
{


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

}

