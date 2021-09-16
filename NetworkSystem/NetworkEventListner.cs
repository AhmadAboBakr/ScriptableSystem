using ScriptableSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NetworkSystem
{
    [System.Serializable]
    public class NetworkUnityEvent :UnityEvent<Message>{}
    [System.Serializable]
    public class MessageEventPair
    {
        public NetworkUnityEvent unityEvent;
        public NetworkEvent scriptableEvent;
        public void OnInvoke(Message data)
        {
            unityEvent.Invoke(data);
        }

    }
    public class NetworkEventListner:EventListner<Message>
    {
        [HideInInspector][SerializeField] private List<MessageEventPair> events;
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
