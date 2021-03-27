// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""22a80f16-e750-4a44-927d-d08c012aebb1"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""c76520d5-40e5-44f6-acc4-c6aabfe88649"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.0001,pressPoint=0.0001)""
                },
                {
                    ""name"": ""LockVerticalRotate"",
                    ""type"": ""Value"",
                    ""id"": ""b1aab858-0033-4ad2-9aa7-ed72a1f2d89c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockHorizontalRotate"",
                    ""type"": ""Value"",
                    ""id"": ""64c3738b-3821-4c00-a2da-e1ca89ffd31e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveObject"",
                    ""type"": ""Value"",
                    ""id"": ""31737439-158c-4753-87a6-84cc73d851a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Value"",
                    ""id"": ""17e68f46-63e9-4b0b-a3dd-d2a85b585ed1"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""793479a8-bc53-4523-ad76-d248cd516811"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b90fb055-a794-4e1d-9082-db950d67b70d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockVerticalRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98a86325-43c6-4866-bb51-2732cdd359be"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockHorizontalRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8efa7e7c-c6d1-4d12-86f2-da9715ea3218"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30541d75-f463-44da-be18-a8c0c82b2074"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
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
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_LockVerticalRotate = m_Player.FindAction("LockVerticalRotate", throwIfNotFound: true);
        m_Player_LockHorizontalRotate = m_Player.FindAction("LockHorizontalRotate", throwIfNotFound: true);
        m_Player_MoveObject = m_Player.FindAction("MoveObject", throwIfNotFound: true);
        m_Player_Escape = m_Player.FindAction("Escape", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_LockVerticalRotate;
    private readonly InputAction m_Player_LockHorizontalRotate;
    private readonly InputAction m_Player_MoveObject;
    private readonly InputAction m_Player_Escape;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @LockVerticalRotate => m_Wrapper.m_Player_LockVerticalRotate;
        public InputAction @LockHorizontalRotate => m_Wrapper.m_Player_LockHorizontalRotate;
        public InputAction @MoveObject => m_Wrapper.m_Player_MoveObject;
        public InputAction @Escape => m_Wrapper.m_Player_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @LockVerticalRotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockVerticalRotate;
                @LockVerticalRotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockVerticalRotate;
                @LockVerticalRotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockVerticalRotate;
                @LockHorizontalRotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockHorizontalRotate;
                @LockHorizontalRotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockHorizontalRotate;
                @LockHorizontalRotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockHorizontalRotate;
                @MoveObject.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObject;
                @MoveObject.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObject;
                @MoveObject.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObject;
                @Escape.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @LockVerticalRotate.started += instance.OnLockVerticalRotate;
                @LockVerticalRotate.performed += instance.OnLockVerticalRotate;
                @LockVerticalRotate.canceled += instance.OnLockVerticalRotate;
                @LockHorizontalRotate.started += instance.OnLockHorizontalRotate;
                @LockHorizontalRotate.performed += instance.OnLockHorizontalRotate;
                @LockHorizontalRotate.canceled += instance.OnLockHorizontalRotate;
                @MoveObject.started += instance.OnMoveObject;
                @MoveObject.performed += instance.OnMoveObject;
                @MoveObject.canceled += instance.OnMoveObject;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnLockVerticalRotate(InputAction.CallbackContext context);
        void OnLockHorizontalRotate(InputAction.CallbackContext context);
        void OnMoveObject(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
