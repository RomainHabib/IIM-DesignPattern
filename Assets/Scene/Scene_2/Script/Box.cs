using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    public void OnTouch(int power)
    {
        Destroy(gameObject);
    }
}
