using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDispatcher : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] EntityMovement _movement;
    [SerializeField] EntityFire _fire;
    [SerializeField] EntityRotation rotation;

    [SerializeField] InputActionReference _pointerPosition;
    [SerializeField] InputActionReference _moveJoystick;
    [SerializeField] InputActionReference _fireButton;

    [SerializeField] private float speed;
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Max(0,value);
    }
    
    private Coroutine MovementTracking { get; set; }

    Vector3 ScreenPositionToWorldPosition(Camera c, Vector2 cursorPosition) => _mainCamera.ScreenToWorldPoint(cursorPosition);

    private void Start()
    {
        // binding
        _fireButton.action.started += FireInput;
        _pointerPosition.action.performed += AimPosition;
        
        _moveJoystick.action.performed += MoveInput;
        _moveJoystick.action.canceled += MoveInputCancel;
    }
    
    private void OnDestroy()
    {
        // binding
        _fireButton.action.started -= FireInput;
        _pointerPosition.action.performed -= AimPosition;
        
        _moveJoystick.action.performed -= MoveInput;
        _moveJoystick.action.canceled -= MoveInputCancel;
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null) return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine()); 
        
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                _movement.PrepareDirection(obj.ReadValue<Vector2>());
                yield return null;
            }
            yield break;
        }
    }

    private void MoveInputCancel(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) return;
        _movement.PrepareDirection(Vector2.zero);
        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    

    private void AimPosition(InputAction.CallbackContext obj)
    {
        var pos = obj.ReadValue<Vector2>();

        rotation.AimPosition = ScreenPositionToWorldPosition(_mainCamera, pos);
    }

    private void FireInput(InputAction.CallbackContext obj)
    {
        float fire = obj.ReadValue<float>();
        
        if (fire > 0)
        {
            _fire.FireBullet(10);
        }
    }
}
