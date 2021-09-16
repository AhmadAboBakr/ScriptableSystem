using ScriptableSystem;
using UnityEngine;
namespace NetworkSystem
{
    [System.Serializable]
    [CreateAssetMenu(menuName ="Network Event")]
    public class NetworkEvent:ScriptableEvent<Message>
    {
        public Message message;
    }
    
}
