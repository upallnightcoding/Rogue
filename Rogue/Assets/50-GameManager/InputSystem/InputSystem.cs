// GENERATED AUTOMATICALLY FROM 'Assets/50-GameManager/InputSystem/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""cfb3870e-65d6-4f24-a97f-26f17e4b8f1e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""acfb84de-2910-4d62-88fa-e412f6aba29f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a12263fc-a84a-4f6c-bf4b-89df3c1b5479"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ad1b2590-9743-4b07-95e2-597bf4b53a23"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defence1"",
                    ""type"": ""Button"",
                    ""id"": ""2151a039-cb80-4c16-b567-ab3a9d845b37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defence2"",
                    ""type"": ""Button"",
                    ""id"": ""ebebf30c-5716-4af8-af73-67427076dcbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defence3"",
                    ""type"": ""Button"",
                    ""id"": ""7a3e9e44-0e4a-46ab-879a-1a284053cedc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defence4"",
                    ""type"": ""Button"",
                    ""id"": ""2237a294-862f-43d4-9f9e-dac905dfdc65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defence5"",
                    ""type"": ""Button"",
                    ""id"": ""2d676255-d3bd-4095-8d31-ecc46e7c3797"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ba12514f-87e8-47fc-9143-e0cfbf625695"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b2f6ea41-4da2-40d7-870d-4db4fc8381f8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c6f7bf6a-9243-4892-8f84-e9aff52148ed"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f124ec97-18e6-40f8-9bba-091659916a8a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5e1bf9ad-7dfa-4bae-8cbb-a53fb84224b9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""076f0486-fc36-42d4-a679-8a7aa238f4ed"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a413d6e9-72dc-4d9e-ba02-b2dbd5777337"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8052edcb-21ed-46f3-b200-d7aa2e5b56a2"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a370c059-0670-4d1e-8f85-824fd256f58e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ebd9f44e-ccea-4c32-ab55-888f611f06e5"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1d2e3957-b64c-4ea3-80b6-e4ef4880a6e7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26f942a3-f1bb-4dc1-9860-6224f4ecd32e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""097ad5d2-aa13-410a-b8fb-5189cb529ca8"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defence1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bf5711e-eac4-4477-8649-4d6838b85de1"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defence2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8f558a1-a0e0-4aab-b996-6af7f77d8f89"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defence3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aed9a7c-9bd3-44a0-bbda-7e269b42cff5"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defence4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96d80d0d-e99c-448f-9854-6e20e5089976"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defence5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        m_Player_Defence1 = m_Player.FindAction("Defence1", throwIfNotFound: true);
        m_Player_Defence2 = m_Player.FindAction("Defence2", throwIfNotFound: true);
        m_Player_Defence3 = m_Player.FindAction("Defence3", throwIfNotFound: true);
        m_Player_Defence4 = m_Player.FindAction("Defence4", throwIfNotFound: true);
        m_Player_Defence5 = m_Player.FindAction("Defence5", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Camera;
    private readonly InputAction m_Player_Defence1;
    private readonly InputAction m_Player_Defence2;
    private readonly InputAction m_Player_Defence3;
    private readonly InputAction m_Player_Defence4;
    private readonly InputAction m_Player_Defence5;
    public struct PlayerActions
    {
        private @InputSystem m_Wrapper;
        public PlayerActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputAction @Defence1 => m_Wrapper.m_Player_Defence1;
        public InputAction @Defence2 => m_Wrapper.m_Player_Defence2;
        public InputAction @Defence3 => m_Wrapper.m_Player_Defence3;
        public InputAction @Defence4 => m_Wrapper.m_Player_Defence4;
        public InputAction @Defence5 => m_Wrapper.m_Player_Defence5;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Defence1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence1;
                @Defence1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence1;
                @Defence1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence1;
                @Defence2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence2;
                @Defence2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence2;
                @Defence2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence2;
                @Defence3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence3;
                @Defence3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence3;
                @Defence3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence3;
                @Defence4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence4;
                @Defence4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence4;
                @Defence4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence4;
                @Defence5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence5;
                @Defence5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence5;
                @Defence5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefence5;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Defence1.started += instance.OnDefence1;
                @Defence1.performed += instance.OnDefence1;
                @Defence1.canceled += instance.OnDefence1;
                @Defence2.started += instance.OnDefence2;
                @Defence2.performed += instance.OnDefence2;
                @Defence2.canceled += instance.OnDefence2;
                @Defence3.started += instance.OnDefence3;
                @Defence3.performed += instance.OnDefence3;
                @Defence3.canceled += instance.OnDefence3;
                @Defence4.started += instance.OnDefence4;
                @Defence4.performed += instance.OnDefence4;
                @Defence4.canceled += instance.OnDefence4;
                @Defence5.started += instance.OnDefence5;
                @Defence5.performed += instance.OnDefence5;
                @Defence5.canceled += instance.OnDefence5;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnDefence1(InputAction.CallbackContext context);
        void OnDefence2(InputAction.CallbackContext context);
        void OnDefence3(InputAction.CallbackContext context);
        void OnDefence4(InputAction.CallbackContext context);
        void OnDefence5(InputAction.CallbackContext context);
    }
}
