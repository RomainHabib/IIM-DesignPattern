using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reference<T> : ScriptableObject, IReferenceSetter<T>
{
    private T instance;
    private IReferenceSetter<T> _referenceSetterImplementation;
    public T Instance => instance;

    void IReferenceSetter<T>.SetInstance(T newInstance)
    {
        instance = newInstance;
    }
}
