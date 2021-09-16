using System;
using UnityEngine;
using ScriptableSystem;
using System.Collections.Generic;

namespace NetworkSystem
{
    [System.Serializable]
    public class StringEventPair
    {
        public NetworkEvent @event;
        public string message;
    }
    [CreateAssetMenu(menuName ="Router")]
    public class ScriptableRouter : ScriptableObject, IRouter
    {
        public List<StringEventPair> Listners;
        public void RouteMessage(Message message)
        {
            Listners[message.name].@event.Invoke(message);
        }
    }
}
