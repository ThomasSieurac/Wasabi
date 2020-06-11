// GENERATED AUTOMATICALLY FROM 'Assets/Tests/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""73872dc0-7217-436d-a757-5eb92e271905"",
            ""actions"": [
                {
                    ""name"": ""Move Lux"",
                    ""type"": ""Value"",
                    ""id"": ""7176d496-568d-403c-9093-b9425ce4f830"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Ban"",
                    ""type"": ""Value"",
                    ""id"": ""e0a65473-36af-4947-95d9-33f8f4151b06"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""93c2c993-6d1c-475d-baff-d5c3f9674775"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox controller 1"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e84735ed-1660-41c7-93f6-f917a92eb82d"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox controller 2"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox controller 1"",
            ""bindingGroup"": ""Xbox controller 1"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Xbox controller 2"",
            ""bindingGroup"": ""Xbox controller 2"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveLux = m_Player.FindAction("Move Lux", throwIfNotFound: true);
        m_Player_MoveBan = m_Player.FindAction("Move Ban", throwIfNotFound: true);
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
    private readonly InputAction m_Player_MoveLux;
    private readonly InputAction m_Player_MoveBan;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLux => m_Wrapper.m_Player_MoveLux;
        public InputAction @MoveBan => m_Wrapper.m_Player_MoveBan;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveLux.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLux;
                @MoveLux.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLux;
                @MoveLux.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLux;
                @MoveBan.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveBan;
                @MoveBan.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveBan;
                @MoveBan.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveBan;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLux.started += instance.OnMoveLux;
                @MoveLux.performed += instance.OnMoveLux;
                @MoveLux.canceled += instance.OnMoveLux;
                @MoveBan.started += instance.OnMoveBan;
                @MoveBan.performed += instance.OnMoveBan;
                @MoveBan.canceled += instance.OnMoveBan;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_Xboxcontroller1SchemeIndex = -1;
    public InputControlScheme Xboxcontroller1Scheme
    {
        get
        {
            if (m_Xboxcontroller1SchemeIndex == -1) m_Xboxcontroller1SchemeIndex = asset.FindControlSchemeIndex("Xbox controller 1");
            return asset.controlSchemes[m_Xboxcontroller1SchemeIndex];
        }
    }
    private int m_Xboxcontroller2SchemeIndex = -1;
    public InputControlScheme Xboxcontroller2Scheme
    {
        get
        {
            if (m_Xboxcontroller2SchemeIndex == -1) m_Xboxcontroller2SchemeIndex = asset.FindControlSchemeIndex("Xbox controller 2");
            return asset.controlSchemes[m_Xboxcontroller2SchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveLux(InputAction.CallbackContext context);
        void OnMoveBan(InputAction.CallbackContext context);
    }
}
