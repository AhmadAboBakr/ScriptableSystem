
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
}
