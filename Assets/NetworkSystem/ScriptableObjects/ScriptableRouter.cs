using System;
using UnityEngine;
using ScriptableSystem;
using System.Collections.Generic;

namespace NetworkSystem
{
    [CreateAssetMenu(menuName ="Router")]
    public class ScriptableRouter : ScriptableObject, IRouter
    {
        public List<NetworkEvent> Listners;
        public void RouteMessage(Message message)
        {
            Listners[message.opCode].Invoke(message);
        }
    }
}
