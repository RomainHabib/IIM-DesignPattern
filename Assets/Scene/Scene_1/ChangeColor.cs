using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColor : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] MeshRenderer _renderer;
    [Header("Conf")]
    [SerializeField] Color _baseColor;
    [SerializeField] Color _overColor;
    [SerializeField] Color _clickColor;

    #region Editor
    void Reset()
    {
        _renderer = GetComponent<MeshRenderer>();
        _baseColor = Color.red;
        _overColor = Color.yellow;
        _clickColor = Color.green;
    }
    void OnValidate()
    {
        UseColor(_baseColor);
    }
    #endregion

    void UseColor(Color c) => _renderer.sharedMaterial.SetColor("_BaseColor", c);

    void Start()
    {
        UseColor(_baseColor);
    }

}
