using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyToggle : MonoBehaviour, ITouchable
{
    // Je veux ouvrir un �v�nement pour les designers pour qu'ils puissent set la couleur du sprite eux m�me
    [SerializeField] private UnityEvent onToggleOn;
    [SerializeField] private UnityEvent onToggleOff;


    public bool IsActive { get; private set; }

    public void OnTouch(int power)
    {
        IsActive = !IsActive;

        UnityEvent e = IsActive ? onToggleOn : onToggleOff;
        e.Invoke();
    }
}
