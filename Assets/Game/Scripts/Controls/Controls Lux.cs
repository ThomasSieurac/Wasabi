// GENERATED AUTOMATICALLY FROM 'Assets/Game/Scripts/Controls/Controls Lux.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlsLux : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlsLux()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls Lux"",
    ""maps"": [
        {
            ""name"": ""Controls lux"",
            ""id"": ""eb6ca348-257e-4f2c-af2a-1c2f0a5bbf93"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""638cbbd1-dec2-40c1-b1c2-0c7586d149b2"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cab4877c-edd6-46cf-b1f3-afe7be49fe4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e645cc83-78a7-4e3f-b115-4d197b7fdd53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use spell"",
                    ""type"": ""Button"",
                    ""id"": ""bdd8a730-0154-4706-817c-d11732587269"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate spell"",
                    ""type"": ""Value"",
                    ""id"": ""820cba7d-4b58-496e-9a77-1cca37a2a9d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""8006422a-1977-4e23-9ef6-3d6a8a7d02da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=1)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ae67757f-efdb-46cd-a81e-ecce8e6a19b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""4c9c8ef2-51c9-4cf2-81f2-438e94db04e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector Controller"",
                    ""id"": ""f639b539-8c77-47dd-a6f4-f5ff00d38ac4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0041df7c-9418-439b-af36-0959b6572aee"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dc7a85ca-1c3a-4b56-af6c-713048dd0e5b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""327b4cb2-b6f8-4d4c-b353-fc783b55eaf3"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""360a474c-01dd-4862-9286-2aa2b5aed975"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector Keyboard"",
                    ""id"": ""bed4911b-199f-4eed-b7aa-90d38b09e238"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5dd5d1c8-f7af-4456-9518-fadefb8a4938"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""293c4ef1-16b4-4b45-96c5-05698ab895b8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c80e7aba-b0a3-41b5-9f74-8db48fbb86d3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""80df563d-2bd6-415b-b141-61551dbfaae7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fc342a47-4507-4904-bc3b-31def39d2a12"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c83c61d9-f74f-41e2-aab3-714e046f62c2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b43aeb97-2210-457f-889c-722b18eedf65"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fab7f90-e707-4603-8ee1-b25bd1c2fe45"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d3531fe-5596-4579-8c97-92a5721324c9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Use spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""594bbc20-e374-4d6e-bdae-2f371d4dd708"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Use spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis keyboard"",
                    ""id"": ""714ba73a-1e49-42e6-b6d6-fe6928ca0a45"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""23d26734-be4a-41c9-aa1c-75d82d580877"",
                    ""path"": ""<Keyboard>/pageUp"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""46a2b9e6-67ba-44eb-9e90-2ff41ce45f5d"",
                    ""path"": ""<Keyboard>/pageDown"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis controller shoulder"",
                    ""id"": ""62ac5460-89dd-4cd9-91db-65a53fb2b4d0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""10b94e2b-4c82-461a-ae85-331349adc157"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b0f3c363-0bfe-463d-a3da-7ccb6b99fe37"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0a9db7d0-48cc-48a4-82ff-a8fa08225156"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e9f8329-7b0d-467a-ace5-220b6540c28f"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""965b4021-96aa-499d-a5ad-e052af2bcaa0"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 2"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""374ff7bd-1877-45fa-8c2a-357440abbd96"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""905f07e0-9390-44e6-a04f-ac6e16e4f4b3"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f39ffe5-f6b4-46e0-b8fe-92c56b6e9cd2"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller 2"",
            ""bindingGroup"": ""Controller 2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller 1"",
            ""bindingGroup"": ""Controller 1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Controls lux
        m_Controlslux = asset.FindActionMap("Controls lux", throwIfNotFound: true);
        m_Controlslux_Move = m_Controlslux.FindAction("Move", throwIfNotFound: true);
        m_Controlslux_Jump = m_Controlslux.FindAction("Jump", throwIfNotFound: true);
        m_Controlslux_Interact = m_Controlslux.FindAction("Interact", throwIfNotFound: true);
        m_Controlslux_Usespell = m_Controlslux.FindAction("Use spell", throwIfNotFound: true);
        m_Controlslux_Rotatespell = m_Controlslux.FindAction("Rotate spell", throwIfNotFound: true);
        m_Controlslux_Respawn = m_Controlslux.FindAction("Respawn", throwIfNotFound: true);
        m_Controlslux_Pause = m_Controlslux.FindAction("Pause", throwIfNotFound: true);
        m_Controlslux_Switch = m_Controlslux.FindAction("Switch", throwIfNotFound: true);
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

    // Controls lux
    private readonly InputActionMap m_Controlslux;
    private IControlsluxActions m_ControlsluxActionsCallbackInterface;
    private readonly InputAction m_Controlslux_Move;
    private readonly InputAction m_Controlslux_Jump;
    private readonly InputAction m_Controlslux_Interact;
    private readonly InputAction m_Controlslux_Usespell;
    private readonly InputAction m_Controlslux_Rotatespell;
    private readonly InputAction m_Controlslux_Respawn;
    private readonly InputAction m_Controlslux_Pause;
    private readonly InputAction m_Controlslux_Switch;
    public struct ControlsluxActions
    {
        private @ControlsLux m_Wrapper;
        public ControlsluxActions(@ControlsLux wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controlslux_Move;
        public InputAction @Jump => m_Wrapper.m_Controlslux_Jump;
        public InputAction @Interact => m_Wrapper.m_Controlslux_Interact;
        public InputAction @Usespell => m_Wrapper.m_Controlslux_Usespell;
        public InputAction @Rotatespell => m_Wrapper.m_Controlslux_Rotatespell;
        public InputAction @Respawn => m_Wrapper.m_Controlslux_Respawn;
        public InputAction @Pause => m_Wrapper.m_Controlslux_Pause;
        public InputAction @Switch => m_Wrapper.m_Controlslux_Switch;
        public InputActionMap Get() { return m_Wrapper.m_Controlslux; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsluxActions set) { return set.Get(); }
        public void SetCallbacks(IControlsluxActions instance)
        {
            if (m_Wrapper.m_ControlsluxActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnInteract;
                @Usespell.started -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnUsespell;
                @Usespell.performed -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnUsespell;
                @Usespell.canceled -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnUsespell;
                @Rotatespell.started -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnRotatespell;
                @Rotatespell.performed -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnRotatespell;
                @Rotatespell.canceled -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnRotatespell;
                @Respawn.started -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnRespawn;
                @Pause.started -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnPause;
                @Switch.started -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_ControlsluxActionsCallbackInterface.OnSwitch;
            }
            m_Wrapper.m_ControlsluxActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Usespell.started += instance.OnUsespell;
                @Usespell.performed += instance.OnUsespell;
                @Usespell.canceled += instance.OnUsespell;
                @Rotatespell.started += instance.OnRotatespell;
                @Rotatespell.performed += instance.OnRotatespell;
                @Rotatespell.canceled += instance.OnRotatespell;
                @Respawn.started += instance.OnRespawn;
                @Respawn.performed += instance.OnRespawn;
                @Respawn.canceled += instance.OnRespawn;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
            }
        }
    }
    public ControlsluxActions @Controlslux => new ControlsluxActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_Controller2SchemeIndex = -1;
    public InputControlScheme Controller2Scheme
    {
        get
        {
            if (m_Controller2SchemeIndex == -1) m_Controller2SchemeIndex = asset.FindControlSchemeIndex("Controller 2");
            return asset.controlSchemes[m_Controller2SchemeIndex];
        }
    }
    private int m_Controller1SchemeIndex = -1;
    public InputControlScheme Controller1Scheme
    {
        get
        {
            if (m_Controller1SchemeIndex == -1) m_Controller1SchemeIndex = asset.FindControlSchemeIndex("Controller 1");
            return asset.controlSchemes[m_Controller1SchemeIndex];
        }
    }
    public interface IControlsluxActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnUsespell(InputAction.CallbackContext context);
        void OnRotatespell(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
    }
}
