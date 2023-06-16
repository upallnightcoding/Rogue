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
    private InputAction mouseAction;

    void Awake()
    {
        inputSystem = new InputSystem();

        moveAction = inputSystem.Player.Move;
        jumpAction = inputSystem.Player.Jump;
        mouseAction = inputSystem.Player.Camera;
    }

    public Vector2 GetMoveDirection()
    {
        return (moveAction.ReadValue<Vector2>());
    }

    public Vector2 GetMouseDirection()
    {
        return (mouseAction.ReadValue<Vector2>());
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        OnJump.Invoke();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        mouseAction.Enable();

        jumpAction.performed += Jump;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        mouseAction.Disable();

        jumpAction.performed -= Jump;
    }
}
