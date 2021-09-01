using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableSystem
{
    [CreateAssetMenu(menuName ="ScriptableSystem/Event")]
    public class ScriptableEvent : ScriptableObject 
    {
        private event Action listners;
        public void Subscribe(Action listner) {
            listners += listner;
        }
        public void Unsubscribe(Action listner)
        {
            listner -= listner;
        }
        public void Invoke()
        {
            listners?.Invoke();
        }
    }

    public class ScriptableEvent<T>
    {
        private event Action<T> listners;

        public void Subscribe(Action<T> listner)
        {
            listners += listner;
        }
        public void Unsubscribe(Action<T> listner)
        {
            listner -= listner;
        }
        public void Invoke(T data)
        {
            listners?.Invoke(data);
        }
    }
}
