

using UnityEngine;

public class ScriptableVector : ScriptableVariable<Vector3>
{
    public override void Parse(string value)
    {
        this.value = JsonUtility.FromJson<Vector3>(value);
    }
}

