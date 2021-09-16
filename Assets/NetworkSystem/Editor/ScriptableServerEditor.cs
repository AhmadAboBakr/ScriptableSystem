using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace NetworkSystem.Editors
{
    [CustomEditor(typeof(ScribtableServer),true)]
    public class ScriptableServerEditor : Editor
    {
        List<Type> types;
        String[] typesNames;
        int currentType = 0;
        void OnEnable()
        {
            types = new List<Type>();
            
            foreach (Type type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                            .Where(mytype => mytype.GetInterfaces().Contains(typeof(IServer))))
            {
                types.Add(type);
            }
            typesNames= new string[types.Count];
            for (int i = 0; i < types.Count; i++)
            {
                typesNames[i] = types[i].Name;
            }
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUI.BeginChangeCheck();
            currentType = EditorGUILayout.Popup(currentType, typesNames);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "changed the type");
            }

        }
        private void CreateInvokeButton()
        {
            if (GUILayout.Button("Raise"))
            {
                var netowrkEvent = (NetworkEvent)this.target;
                netowrkEvent.Invoke(netowrkEvent.message);
            }

        }
    }
}

