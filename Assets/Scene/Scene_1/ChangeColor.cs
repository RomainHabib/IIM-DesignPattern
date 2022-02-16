using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColor : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
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

    public void OnPointerDown(PointerEventData eventData)
    {
        _renderer.sharedMaterial.color = _clickColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _renderer.sharedMaterial.color = _overColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _renderer.sharedMaterial.color = _baseColor;
    }

    #region PAUL

    

    #endregion

    #region Ile-De_France
    // City Paris = new City();
    // City Montesson = new City();
    // Human Romain = new Human();
    // Romain.city = Montesson;
    // Romain.destination = FindObjectOfType(McDonalds as fastFood);
    #endregion
}
