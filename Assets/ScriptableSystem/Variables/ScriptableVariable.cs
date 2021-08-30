using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
public abstract class ScriptableVariable : ScriptableObject
{
    public abstract override string ToString();
    public abstract void Parse(string value);
}
public abstract class ScriptableVariable<T> : ScriptableVariable 
{
    public T value;
    public override string ToString()
    {
        return value.ToString() ;
    }

    public static implicit operator T(ScriptableVariable<T> value)
    {
        return value.value;
    }
}
