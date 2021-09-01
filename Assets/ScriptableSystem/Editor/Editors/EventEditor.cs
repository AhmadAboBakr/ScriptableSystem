
using UnityEngine;
using UnityEditor;
namespace ScriptableSystem.Editors
{
    [CustomEditor(typeof(ScriptableEvent))]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (Application.isPlaying)
            {
                CreateInvokeButton();
            }
        }

        private  void CreateInvokeButton()
        {
            if (GUILayout.Button("Raise"))
            {
                ((ScriptableEvent)this.target).Invoke();
            }
        }
    }
}