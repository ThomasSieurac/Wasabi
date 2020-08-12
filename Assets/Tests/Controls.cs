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
                    ""name"": ""2D Vector"",
                    ""id"": ""952fd4f5-0ae0-4555-af3c-1be34e4f12e0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Lux"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dd0290da-98a6-4dfe-baaa-46186977839e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9fc38612-bc31-4640-8ff3-0c042c809d56"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7c118569-b475-4f88-850a-01dec554d0a8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e2431d44-2335-499f-9357-ed028d5eb117"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ccf26170-b19b-46b0-93a4-3b0daad89995"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ban"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""895832d1-d301-4449-85e7-a21174cec691"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""30692b95-12ea-4278-932f-ba1b2984cac1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""24790a94-6a7b-4c71-8ff7-eaf7acc34cc2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2a6e9601-28f9-4fd3-ad49-5f3a456d07f1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        },
        {
            ""name"": ""Debug"",
            ""bindingGroup"": ""Debug"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Debug 2"",
            ""bindingGroup"": ""Debug 2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
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
    private int m_DebugSchemeIndex = -1;
    public InputControlScheme DebugScheme
    {
        get
        {
            if (m_DebugSchemeIndex == -1) m_DebugSchemeIndex = asset.FindControlSchemeIndex("Debug");
            return asset.controlSchemes[m_DebugSchemeIndex];
        }
    }
    private int m_Debug2SchemeIndex = -1;
    public InputControlScheme Debug2Scheme
    {
        get
        {
            if (m_Debug2SchemeIndex == -1) m_Debug2SchemeIndex = asset.FindControlSchemeIndex("Debug 2");
            return asset.controlSchemes[m_Debug2SchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveLux(InputAction.CallbackContext context);
        void OnMoveBan(InputAction.CallbackContext context);
    }
}
