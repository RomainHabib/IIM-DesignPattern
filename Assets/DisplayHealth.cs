using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] PlayerEntity _player;
    [SerializeField] TextMeshProUGUI _text;

    void UpdateDisplayedHealth(int newValue) => _text.text = newValue.ToString();

    private void Start()
    {
        // binding
        _player.OnHealthChanged += playerHealthChanged;

    }

    private void OnDestroy()
    {
        _player.OnHealthChanged -= playerHealthChanged;
    }

    private void playerHealthChanged(int obj)
    {
        UpdateDisplayedHealth(obj);
    }

}
