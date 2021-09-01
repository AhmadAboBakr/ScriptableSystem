using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

namespace ScriptableSystem.Editors
{
    [CustomPropertyDrawer(typeof(ScriptableInt))]
    [CustomPropertyDrawer(typeof(ScriptableFloat))]
    [CustomPropertyDrawer(typeof(ScriptableVector))]
    public class ScriptableVariableDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!EditorPrefs.HasKey("variablePath"))
            {
                EditorPrefs.SetString("variablePath", "Assets/");
                //AssetDatabase.CreateFolder("/","Variables");
            }
            var content = EditorGUI.BeginProperty(position, label, property);
            var variableReffrence = (IScriptableVariable)property.objectReferenceValue;

            if (variableReffrence == null)
            {
                DrawNullDrawer(position, property);
            }
            else
            {
                DrawEditableDrawer(position, property);
            }

            EditorGUI.EndProperty();
        }
        private void DrawEditableDrawer(Rect position, SerializedProperty property)
        {
            position.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property);
            if (property.objectReferenceValue != null)
            {
                EditorGUI.indentLevel++;
                position.y += EditorGUIUtility.singleLineHeight;
                position.width *= .9f;
                var serializedObject = new SerializedObject(property.objectReferenceValue);
                EditorGUI.PropertyField(position, serializedObject.FindProperty("value"));
                serializedObject.ApplyModifiedProperties();
                EditorGUI.indentLevel--;

            }
        }

        private void DrawNullDrawer(Rect position, SerializedProperty property)
        {
            position.width = position.width * 2 / 3 - 2;
            EditorGUI.PropertyField(position, property);
            position.x += position.width + 2;
            position.width = position.width / 2;
            if (GUI.Button(position, "Assign"))
            {

                var type = property.type.Substring(6);
                type = type.Substring(0, type.Length - 1);
                var assetsGUID = AssetDatabase.FindAssets("t:" + type + " " + property.name);
                if (assetsGUID.Length == 0)
                {
                    DisplayCreationDialoge(property, type);
                }
                else
                {
                    AssignVariable(property, assetsGUID);
                }
            }
        }
        private static void AssignVariable(SerializedProperty property, string[] assetsGUID)
        {
            var path = AssetDatabase.GUIDToAssetPath(assetsGUID[0]);
            var obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
            property.objectReferenceValue = obj;
        }

        private static void DisplayCreationDialoge(SerializedProperty property, string type)
        {
            var directory = EditorPrefs.GetString("variablePath");
            // Todo can't find asset Do something here 
            var answer = EditorUtility.DisplayDialog(
                "Can't find variable",
                $"can't find a variable with the name: {property.name} do you want to create it in the default directory{directory}",
                "Yes",
                "No");

            if (answer)
            {
                var instance = ScriptableObject.CreateInstance(type);
                AssetDatabase.CreateAsset(instance, EditorPrefs.GetString("variablePath") + property.name + ".asset");
                property.objectReferenceValue = instance;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.objectReferenceValue == null)
            {
                return EditorGUIUtility.singleLineHeight;
            }
            return EditorGUIUtility.singleLineHeight * 2;
        }
    }
}