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
                    ""name"": ""VerticalRotate"",
                    ""type"": ""Value"",
                    ""id"": ""b1aab858-0033-4ad2-9aa7-ed72a1f2d89c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HorizontalRotate"",
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
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""523a519f-baf2-4d6d-b8d6-6241e53a55ff"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalRotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0c4855d8-29cf-4236-92c7-a30b279f047e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""092a0637-f41c-4622-8391-d9a08cb79933"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""49805fc1-73b9-43ec-bf4d-d64184aec605"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalRotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0d58ea1f-1b29-4e51-b65d-bba4c9b022a5"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""d2f06a64-06a0-4851-afb4-fb32e07e827c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""43995982-ec77-4a87-9460-1ed239e0ad1b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveObject"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""422c7cc1-d558-43e2-9896-c6f1cbf33ba2"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""fa70d505-5a54-4924-9b91-3c86b5f364e2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_VerticalRotate = m_Player.FindAction("VerticalRotate", throwIfNotFound: true);
        m_Player_HorizontalRotate = m_Player.FindAction("HorizontalRotate", throwIfNotFound: true);
        m_Player_MoveObject = m_Player.FindAction("MoveObject", throwIfNotFound: true);
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
    private readonly InputAction m_Player_VerticalRotate;
    private readonly InputAction m_Player_HorizontalRotate;
    private readonly InputAction m_Player_MoveObject;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @VerticalRotate => m_Wrapper.m_Player_VerticalRotate;
        public InputAction @HorizontalRotate => m_Wrapper.m_Player_HorizontalRotate;
        public InputAction @MoveObject => m_Wrapper.m_Player_MoveObject;
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
                @VerticalRotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalRotate;
                @VerticalRotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalRotate;
                @VerticalRotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalRotate;
                @HorizontalRotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalRotate;
                @HorizontalRotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalRotate;
                @HorizontalRotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalRotate;
                @MoveObject.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObject;
                @MoveObject.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObject;
                @MoveObject.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveObject;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @VerticalRotate.started += instance.OnVerticalRotate;
                @VerticalRotate.performed += instance.OnVerticalRotate;
                @VerticalRotate.canceled += instance.OnVerticalRotate;
                @HorizontalRotate.started += instance.OnHorizontalRotate;
                @HorizontalRotate.performed += instance.OnHorizontalRotate;
                @HorizontalRotate.canceled += instance.OnHorizontalRotate;
                @MoveObject.started += instance.OnMoveObject;
                @MoveObject.performed += instance.OnMoveObject;
                @MoveObject.canceled += instance.OnMoveObject;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnVerticalRotate(InputAction.CallbackContext context);
        void OnHorizontalRotate(InputAction.CallbackContext context);
        void OnMoveObject(InputAction.CallbackContext context);
    }
}
