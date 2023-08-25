using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void Rotation();
public delegate void Movement(Vector2 direction);
public class Player : MonoBehaviour
{
    public Rotation rotationEvent;
    public Movement movementEvent;
    private Vector2 _direction = new Vector2();

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        _direction = inputContext.ReadValue<Vector2>();
        movementEvent?.Invoke(_direction);
    }

    public void SetRotation(InputAction.CallbackContext inputContext)
    {
        rotationEvent?.Invoke();
    }
}
