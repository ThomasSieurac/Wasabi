// GENERATED AUTOMATICALLY FROM 'Assets/Game/Scripts/Controls/Controls Ban.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlsBan : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlsBan()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls Ban"",
    ""maps"": [
        {
            ""name"": ""Controls ban"",
            ""id"": ""b3ca5d59-f9f6-40a7-bf3a-63a764071cc3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""891fdd9c-ae73-4e94-aed2-79586b927fa7"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e042ed82-959a-4f85-88ef-b0f9041405b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""531a1dcb-7fcd-4b58-a2ea-42221c3999f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use spell"",
                    ""type"": ""Button"",
                    ""id"": ""de03b86b-1157-46eb-9dc3-5a6ee0943788"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate spell"",
                    ""type"": ""Value"",
                    ""id"": ""156ca60c-658a-4ed6-97e0-ed323f58d826"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn"",
                    ""type"": ""Button"",
                    ""id"": ""303cca4d-ce42-4b35-a828-67af0d34dce0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=1)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""587223d5-063b-4db8-9343-d21a63cb0766"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector Controller"",
                    ""id"": ""6c476e7f-f3a5-449b-9760-59e59d9a26d2"",
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
                    ""id"": ""1058a4e6-e29e-4863-8a88-09cc8359add9"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""331bd3a1-dbde-4a17-a599-9fa444901c69"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""78bc65e0-c6fe-4eda-960f-94245591f8f6"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""62ffc4a7-e86b-41cf-9d87-dd7656e80dbe"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector Keyboard"",
                    ""id"": ""b6a269cd-d7e4-41a9-99e8-a3f60464c1f4"",
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
                    ""id"": ""fe049239-921d-4c18-8feb-24fc15e5ffe5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""27bb1710-0472-457a-a1ce-72f7ffdeaa50"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6abaa35e-28b4-439a-9100-137af02edb8d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6255ef10-b11a-47f0-940a-122784eb3b8f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c22223a7-3c29-44e8-88a5-0cd340d77cbc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1913a9d8-db04-46ce-b984-e773db776b72"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f57b5797-da5e-4e3d-b555-5214925991da"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2a95622-b0a1-446f-b8c2-106ff312a02b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e439cc0-de55-4ec7-b175-16616f47a68c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Use spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1da98661-2ff9-47b5-af93-2586fc592268"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Use spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis keyboard"",
                    ""id"": ""3c06c162-c451-4019-9628-30f27bb7e123"",
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
                    ""id"": ""c3cfe61d-23db-4997-b506-4358c8e466f5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""578674e0-16bf-4765-a137-3534f01cfef2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis controller shoulder"",
                    ""id"": ""c7bc045e-ee31-4081-a216-ae261c4ee21b"",
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
                    ""id"": ""1993b2c9-6fca-4a0d-af83-2207ac6578f7"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""01299ff2-1aa9-440a-8e17-e799f97fc7be"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Rotate spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e081af91-f839-4425-8159-9bdfa7974131"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f63921e7-2c1e-4ce8-b6e1-a9360f2edec9"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Respawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6be2d029-d6a9-4e33-9162-0d37b6fbe536"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller 1"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d34af8ca-4e63-46f6-9b87-09edbd597302"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
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
            ""name"": ""Controller 1"",
            ""bindingGroup"": ""Controller 1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
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
        }
    ]
}");
        // Controls ban
        m_Controlsban = asset.FindActionMap("Controls ban", throwIfNotFound: true);
        m_Controlsban_Move = m_Controlsban.FindAction("Move", throwIfNotFound: true);
        m_Controlsban_Jump = m_Controlsban.FindAction("Jump", throwIfNotFound: true);
        m_Controlsban_Interact = m_Controlsban.FindAction("Interact", throwIfNotFound: true);
        m_Controlsban_Usespell = m_Controlsban.FindAction("Use spell", throwIfNotFound: true);
        m_Controlsban_Rotatespell = m_Controlsban.FindAction("Rotate spell", throwIfNotFound: true);
        m_Controlsban_Respawn = m_Controlsban.FindAction("Respawn", throwIfNotFound: true);
        m_Controlsban_Pause = m_Controlsban.FindAction("Pause", throwIfNotFound: true);
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

    // Controls ban
    private readonly InputActionMap m_Controlsban;
    private IControlsbanActions m_ControlsbanActionsCallbackInterface;
    private readonly InputAction m_Controlsban_Move;
    private readonly InputAction m_Controlsban_Jump;
    private readonly InputAction m_Controlsban_Interact;
    private readonly InputAction m_Controlsban_Usespell;
    private readonly InputAction m_Controlsban_Rotatespell;
    private readonly InputAction m_Controlsban_Respawn;
    private readonly InputAction m_Controlsban_Pause;
    public struct ControlsbanActions
    {
        private @ControlsBan m_Wrapper;
        public ControlsbanActions(@ControlsBan wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controlsban_Move;
        public InputAction @Jump => m_Wrapper.m_Controlsban_Jump;
        public InputAction @Interact => m_Wrapper.m_Controlsban_Interact;
        public InputAction @Usespell => m_Wrapper.m_Controlsban_Usespell;
        public InputAction @Rotatespell => m_Wrapper.m_Controlsban_Rotatespell;
        public InputAction @Respawn => m_Wrapper.m_Controlsban_Respawn;
        public InputAction @Pause => m_Wrapper.m_Controlsban_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Controlsban; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsbanActions set) { return set.Get(); }
        public void SetCallbacks(IControlsbanActions instance)
        {
            if (m_Wrapper.m_ControlsbanActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnInteract;
                @Usespell.started -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnUsespell;
                @Usespell.performed -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnUsespell;
                @Usespell.canceled -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnUsespell;
                @Rotatespell.started -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnRotatespell;
                @Rotatespell.performed -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnRotatespell;
                @Rotatespell.canceled -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnRotatespell;
                @Respawn.started -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnRespawn;
                @Respawn.performed -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnRespawn;
                @Respawn.canceled -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnRespawn;
                @Pause.started -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ControlsbanActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ControlsbanActionsCallbackInterface = instance;
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
            }
        }
    }
    public ControlsbanActions @Controlsban => new ControlsbanActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
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
    private int m_Controller2SchemeIndex = -1;
    public InputControlScheme Controller2Scheme
    {
        get
        {
            if (m_Controller2SchemeIndex == -1) m_Controller2SchemeIndex = asset.FindControlSchemeIndex("Controller 2");
            return asset.controlSchemes[m_Controller2SchemeIndex];
        }
    }
    public interface IControlsbanActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnUsespell(InputAction.CallbackContext context);
        void OnRotatespell(InputAction.CallbackContext context);
        void OnRespawn(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
