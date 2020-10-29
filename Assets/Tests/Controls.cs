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
            ""name"": ""Ban"",
            ""id"": ""37a53b9b-1fe8-4345-b723-16b5cc3ee895"",
            ""actions"": [
                {
                    ""name"": ""Move Ban"",
                    ""type"": ""Value"",
                    ""id"": ""9ceb26d7-b960-4dc6-ab2e-1f6be6013488"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""abec1317-33f6-464f-bb9c-6fdf047e01b0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox controller 2"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e1cd9337-9537-4e92-ad84-233b494604a3"",
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
                    ""id"": ""45aca6be-168d-408b-9291-286318cca84b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug 1"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0cf4fb4a-cb70-4eea-82d0-e1c7ee293176"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug 1"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f35b3d17-cd0c-4ca8-86cb-bb0dd5733b8d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug 1"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7a81865d-f80b-4ec8-8ba6-d472bd95df5c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug 1"",
                    ""action"": ""Move Ban"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Lux"",
            ""id"": ""e758516e-7977-49c4-92f4-148c5e40f028"",
            ""actions"": [
                {
                    ""name"": ""Move Lux"",
                    ""type"": ""Value"",
                    ""id"": ""fb760b1e-cf7c-48ff-84c9-7723b0a57029"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c70133ec-6644-4db2-9ad5-4934237acb2d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller 1"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""62566a7f-219b-47aa-befb-7ac646c7bc2b"",
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
                    ""id"": ""2e57508d-66a4-451e-ac76-5aa2ea12008b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug 2"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0fa67fe9-ca0e-4b94-a26a-440913496219"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug 2"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eb2c4bbc-93e7-4533-b048-925b9b1fb634"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug 2"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0c2dbe6e-f7ba-48ab-bf9f-aa59fff5b858"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug 2"",
                    ""action"": ""Move Lux"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox Controller 1"",
            ""bindingGroup"": ""Xbox Controller 1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
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
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Debug 1"",
            ""bindingGroup"": ""Debug 1"",
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
        // Ban
        m_Ban = asset.FindActionMap("Ban", throwIfNotFound: true);
        m_Ban_MoveBan = m_Ban.FindAction("Move Ban", throwIfNotFound: true);
        // Lux
        m_Lux = asset.FindActionMap("Lux", throwIfNotFound: true);
        m_Lux_MoveLux = m_Lux.FindAction("Move Lux", throwIfNotFound: true);
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

    // Ban
    private readonly InputActionMap m_Ban;
    private IBanActions m_BanActionsCallbackInterface;
    private readonly InputAction m_Ban_MoveBan;
    public struct BanActions
    {
        private @Controls m_Wrapper;
        public BanActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveBan => m_Wrapper.m_Ban_MoveBan;
        public InputActionMap Get() { return m_Wrapper.m_Ban; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BanActions set) { return set.Get(); }
        public void SetCallbacks(IBanActions instance)
        {
            if (m_Wrapper.m_BanActionsCallbackInterface != null)
            {
                @MoveBan.started -= m_Wrapper.m_BanActionsCallbackInterface.OnMoveBan;
                @MoveBan.performed -= m_Wrapper.m_BanActionsCallbackInterface.OnMoveBan;
                @MoveBan.canceled -= m_Wrapper.m_BanActionsCallbackInterface.OnMoveBan;
            }
            m_Wrapper.m_BanActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveBan.started += instance.OnMoveBan;
                @MoveBan.performed += instance.OnMoveBan;
                @MoveBan.canceled += instance.OnMoveBan;
            }
        }
    }
    public BanActions @Ban => new BanActions(this);

    // Lux
    private readonly InputActionMap m_Lux;
    private ILuxActions m_LuxActionsCallbackInterface;
    private readonly InputAction m_Lux_MoveLux;
    public struct LuxActions
    {
        private @Controls m_Wrapper;
        public LuxActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLux => m_Wrapper.m_Lux_MoveLux;
        public InputActionMap Get() { return m_Wrapper.m_Lux; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LuxActions set) { return set.Get(); }
        public void SetCallbacks(ILuxActions instance)
        {
            if (m_Wrapper.m_LuxActionsCallbackInterface != null)
            {
                @MoveLux.started -= m_Wrapper.m_LuxActionsCallbackInterface.OnMoveLux;
                @MoveLux.performed -= m_Wrapper.m_LuxActionsCallbackInterface.OnMoveLux;
                @MoveLux.canceled -= m_Wrapper.m_LuxActionsCallbackInterface.OnMoveLux;
            }
            m_Wrapper.m_LuxActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLux.started += instance.OnMoveLux;
                @MoveLux.performed += instance.OnMoveLux;
                @MoveLux.canceled += instance.OnMoveLux;
            }
        }
    }
    public LuxActions @Lux => new LuxActions(this);
    private int m_XboxController1SchemeIndex = -1;
    public InputControlScheme XboxController1Scheme
    {
        get
        {
            if (m_XboxController1SchemeIndex == -1) m_XboxController1SchemeIndex = asset.FindControlSchemeIndex("Xbox Controller 1");
            return asset.controlSchemes[m_XboxController1SchemeIndex];
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
    private int m_Debug1SchemeIndex = -1;
    public InputControlScheme Debug1Scheme
    {
        get
        {
            if (m_Debug1SchemeIndex == -1) m_Debug1SchemeIndex = asset.FindControlSchemeIndex("Debug 1");
            return asset.controlSchemes[m_Debug1SchemeIndex];
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
    public interface IBanActions
    {
        void OnMoveBan(InputAction.CallbackContext context);
    }
    public interface ILuxActions
    {
        void OnMoveLux(InputAction.CallbackContext context);
    }
}
