using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour
{
    public static event Action OnJump = delegate {};

    private InputSystem inputSystem;
    private InputAction moveAction;
    private InputAction jumpAction;

    void Awake()
    {
        inputSystem = new InputSystem();

        moveAction = inputSystem.Player.Move;
        jumpAction = inputSystem.Player.Jump;
    }

    public Vector2 GetMoveDirection()
    {
        return (moveAction.ReadValue<Vector2>());
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        OnJump.Invoke();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();

        jumpAction.performed += Jump;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();

        jumpAction.performed -= Jump;
    }
}
