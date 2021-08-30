using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ScriptableSystem
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