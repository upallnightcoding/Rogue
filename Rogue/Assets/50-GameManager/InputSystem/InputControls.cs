using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour
{
    public static event Action OnJump = delegate {};

    public static event Action OnDefence1 = delegate { };
    public static event Action OnDefence2 = delegate { };
    public static event Action OnDefence3 = delegate { };
    public static event Action OnDefence4 = delegate { };
    public static event Action OnDefence5 = delegate { };

    private InputSystem inputSystem;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction mouseAction;

    private InputAction defence1Action;
    private InputAction defence2Action;
    private InputAction defence3Action;
    private InputAction defence4Action;
    private InputAction defence5Action;

    void Awake()
    {
        inputSystem = new InputSystem();

        moveAction = inputSystem.Player.Move;
        jumpAction = inputSystem.Player.Jump;
        mouseAction = inputSystem.Player.Camera;

        defence1Action = inputSystem.Player.Defence1;
        defence2Action = inputSystem.Player.Defence2;
        defence3Action = inputSystem.Player.Defence3;
        defence4Action = inputSystem.Player.Defence4;
        defence5Action = inputSystem.Player.Defence5;
    }

    public Vector2 GetMoveDirection()
    {
        return (moveAction.ReadValue<Vector2>());
    }

    public Vector2 GetMouseDirection()
    {
        return (mouseAction.ReadValue<Vector2>());
    }

    private void Jump(InputAction.CallbackContext context) => OnJump.Invoke();

    private void Defence1(InputAction.CallbackContext context) => OnDefence1.Invoke();
    private void Defence2(InputAction.CallbackContext context) => OnDefence2.Invoke();
    private void Defence3(InputAction.CallbackContext context) => OnDefence3.Invoke();
    private void Defence4(InputAction.CallbackContext context) => OnDefence4.Invoke();
    private void Defence5(InputAction.CallbackContext context) => OnDefence5.Invoke();

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        mouseAction.Enable();

        defence1Action.Enable();
        defence2Action.Enable();
        defence3Action.Enable();
        defence4Action.Enable();
        defence5Action.Enable();

        jumpAction.performed += Jump;

        defence1Action.performed += Defence1;
        defence2Action.performed += Defence2;
        defence3Action.performed += Defence3;
        defence4Action.performed += Defence4;
        defence5Action.performed += Defence5;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        mouseAction.Disable();

        defence1Action.Disable();
        defence2Action.Disable();
        defence3Action.Disable();
        defence4Action.Disable();
        defence5Action.Disable();

        jumpAction.performed -= Jump;

        defence1Action.performed -= Defence1;
        defence2Action.performed -= Defence2;
        defence3Action.performed -= Defence3;
        defence4Action.performed -= Defence4;
        defence5Action.performed -= Defence5;
    }
}
