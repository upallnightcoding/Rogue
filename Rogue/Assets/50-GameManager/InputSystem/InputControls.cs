using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour
{
    public static event Action OnJump = delegate {};

    public static event Action OnOffensive1 = delegate { };
    public static event Action OnOffensive2 = delegate { };
    public static event Action OnOffensive3 = delegate { };
    public static event Action OnOffensive4 = delegate { };
    public static event Action OnOffensive5 = delegate { };

    public static event Action OnDrawWeapon = delegate { };

    private InputSystem inputSystem;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction mouseAction;
    private InputAction drawWeaponAction;

    private InputAction offensive1Action;
    private InputAction offensive2Action;
    private InputAction offensive3Action;
    private InputAction offensive4Action;
    private InputAction offensive5Action;

    void Awake()
    {
        inputSystem = new InputSystem();

        moveAction = inputSystem.Player.Move;
        jumpAction = inputSystem.Player.Jump;
        mouseAction = inputSystem.Player.Camera;
        drawWeaponAction = inputSystem.Player.DrawWeapon;

        offensive1Action = inputSystem.Player.Defence1;
        offensive2Action = inputSystem.Player.Defence2;
        offensive3Action = inputSystem.Player.Defence3;
        offensive4Action = inputSystem.Player.Defence4;
        offensive5Action = inputSystem.Player.Defence5;
    }

    public Vector2 GetMoveDirection()
    {
        return (moveAction.ReadValue<Vector2>());
    }

    public Vector2 GetMouseDirection()
    {
        return (mouseAction.ReadValue<Vector2>());
    }

    public bool GetLeftMouseButton() => Mouse.current.leftButton.isPressed;

    public bool GetRightMouseButton() => Mouse.current.rightButton.isPressed;

    private void Jump(InputAction.CallbackContext context) => OnJump.Invoke();

    private void DrawWeapon(InputAction.CallbackContext context) => OnDrawWeapon.Invoke();

    private void Offensive1(InputAction.CallbackContext context) => OnOffensive1.Invoke();
    private void Offensive2(InputAction.CallbackContext context) => OnOffensive2.Invoke();
    private void Offensive3(InputAction.CallbackContext context) => OnOffensive3.Invoke();
    private void Offensive4(InputAction.CallbackContext context) => OnOffensive4.Invoke();
    private void Offensive5(InputAction.CallbackContext context) => OnOffensive5.Invoke();

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        mouseAction.Enable();

        offensive1Action.Enable();
        offensive2Action.Enable();
        offensive3Action.Enable();
        offensive4Action.Enable();
        offensive5Action.Enable();

        drawWeaponAction.Enable();

        drawWeaponAction.performed -= DrawWeapon;

        jumpAction.performed += Jump;

        offensive1Action.performed += Offensive1;
        offensive2Action.performed += Offensive2;
        offensive3Action.performed += Offensive3;
        offensive4Action.performed += Offensive4;
        offensive5Action.performed += Offensive5;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        mouseAction.Disable();
        drawWeaponAction.Disable();

        offensive1Action.Disable();
        offensive2Action.Disable();
        offensive3Action.Disable();
        offensive4Action.Disable();
        offensive5Action.Disable();

        jumpAction.performed -= Jump;

        drawWeaponAction.performed -= DrawWeapon;

        offensive1Action.performed -= Offensive1;
        offensive2Action.performed -= Offensive2;
        offensive3Action.performed -= Offensive3;
        offensive4Action.performed -= Offensive4;
        offensive5Action.performed -= Offensive5;
    }
}
