using UnityEngine;
using UnityEditor;
namespace NetworkSystem.Editors
{
    [CustomEditor(typeof(NetworkSystem.NetworkEvent))]
    public class NetworkEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying)
            {
                CreateInvokeButton();
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

