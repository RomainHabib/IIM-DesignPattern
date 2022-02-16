using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private CameraReference camRef;

    #region EDITOR
    private void Reset()
    {
        camera = GetComponent<Camera>();
    }
    #endregion

    private void Awake()
    {
        IReferenceSetter<Camera> reference = camRef;
        reference.SetInstance(camera);
    }
}
