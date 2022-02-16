using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReferenceSetter<T>
{
    public void SetInstance(T newInstance);
}
