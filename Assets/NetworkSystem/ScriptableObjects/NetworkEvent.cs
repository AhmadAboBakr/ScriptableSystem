using ScriptableSystem;
using UnityEngine;
namespace NetworkSystem
{
    [CreateAssetMenu(menuName ="Network Event")]
    public class NetworkEvent:ScriptableEvent<Message>
    {
    }
    
}
