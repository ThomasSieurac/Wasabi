// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/Controls Ban.inputactions'

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
            ""name"": ""Debug"",
            ""id"": ""bc49999f-2137-4d8c-996f-92215174d9f3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4788a6d1-79b7-4203-8651-06a389621fc6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate Spells"",
                    ""type"": ""Value"",
                    ""id"": ""e850e62a-de61-4572-a733-d3873d7aa2d5"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Show Spells"",
                    ""type"": ""Button"",
                    ""id"": ""912ab5f4-5dfb-46d7-83da-504a566efa03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c6f2ab14-b330-4bb5-a0e9-4a550105d8a7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""072cc822-9e52-4884-8d8b-95ff4ea96c83"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e6384410-7593-4290-9aa4-b5fa4ce2227c"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""86f583ae-8abb-46c0-8339-efa24a91b2ff"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Show Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c9d3ef9f-6a6d-4492-84a4-b3ddd1d3186a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a6eaf213-51a6-4225-957b-e86f74262081"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""67918923-b27d-4268-aeef-1057714fc448"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Controler"",
            ""id"": ""41369b3b-6f6e-4e1b-9ebd-56c100996bb3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4aa7c317-4985-4cb2-b76e-49531872e96e"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate Spells"",
                    ""type"": ""Value"",
                    ""id"": ""77166dd6-84fd-4e82-9df4-1285503d6f13"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Spells"",
                    ""type"": ""Button"",
                    ""id"": ""85257797-53b8-45de-8ae9-ed6285296464"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Show Spells"",
                    ""type"": ""Button"",
                    ""id"": ""b13ba253-3de3-424e-b44d-a8b0f26546d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""20153402-df35-4ba1-aea8-ccb957748821"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Character"",
                    ""type"": ""Button"",
                    ""id"": ""28c2e8a8-433e-4f48-8a92-2f50cd17ff00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""4e57bc8c-f9cf-4005-acf2-3b8db1a10c58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Shoulder"",
                    ""id"": ""8271f6b3-ea7a-4a7f-8118-7d8f1d62f155"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c7825b55-327b-4b54-bb37-a17df0711142"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""45773abf-9694-4f6e-bb00-bdf08f0a3320"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f502f834-4cea-4489-89ea-75e4c6992f3e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Show Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ed58794d-91ac-42a6-91e1-ed94d9b108ea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""ed174b74-d4d7-43b8-83cf-9aadb6db1003"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""14619996-cb61-4125-844d-8947a0534f1e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""377359f0-f4bf-473a-a4c6-aaaff17ae4d8"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""e6171cf4-db61-414a-a65d-c430dea7ec72"",
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
                    ""id"": ""7733312f-7b51-47c4-a7ef-30c26a897122"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82d26018-3811-4a75-99a3-fe72d229c6d0"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41a8fc66-3f6a-4b80-b2be-5bcbbcdbf6eb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89defe78-c1f2-47f1-9661-9b473c3c61be"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""167f9dd5-7efc-4607-9372-5d945fa577d7"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change Character"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller 1"",
            ""bindingGroup"": ""Controller 1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_Move = m_Debug.FindAction("Move", throwIfNotFound: true);
        m_Debug_RotateSpells = m_Debug.FindAction("Rotate Spells", throwIfNotFound: true);
        m_Debug_ShowSpells = m_Debug.FindAction("Show Spells", throwIfNotFound: true);
        // Controler
        m_Controler = asset.FindActionMap("Controler", throwIfNotFound: true);
        m_Controler_Move = m_Controler.FindAction("Move", throwIfNotFound: true);
        m_Controler_RotateSpells = m_Controler.FindAction("Rotate Spells", throwIfNotFound: true);
        m_Controler_UseSpells = m_Controler.FindAction("Use Spells", throwIfNotFound: true);
        m_Controler_ShowSpells = m_Controler.FindAction("Show Spells", throwIfNotFound: true);
        m_Controler_Jump = m_Controler.FindAction("Jump", throwIfNotFound: true);
        m_Controler_ChangeCharacter = m_Controler.FindAction("Change Character", throwIfNotFound: true);
        m_Controler_Pause = m_Controler.FindAction("Pause", throwIfNotFound: true);
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

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_Move;
    private readonly InputAction m_Debug_RotateSpells;
    private readonly InputAction m_Debug_ShowSpells;
    public struct DebugActions
    {
        private @ControlsBan m_Wrapper;
        public DebugActions(@ControlsBan wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Debug_Move;
        public InputAction @RotateSpells => m_Wrapper.m_Debug_RotateSpells;
        public InputAction @ShowSpells => m_Wrapper.m_Debug_ShowSpells;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnMove;
                @RotateSpells.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnRotateSpells;
                @RotateSpells.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnRotateSpells;
                @RotateSpells.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnRotateSpells;
                @ShowSpells.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnShowSpells;
                @ShowSpells.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnShowSpells;
                @ShowSpells.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnShowSpells;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RotateSpells.started += instance.OnRotateSpells;
                @RotateSpells.performed += instance.OnRotateSpells;
                @RotateSpells.canceled += instance.OnRotateSpells;
                @ShowSpells.started += instance.OnShowSpells;
                @ShowSpells.performed += instance.OnShowSpells;
                @ShowSpells.canceled += instance.OnShowSpells;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);

    // Controler
    private readonly InputActionMap m_Controler;
    private IControlerActions m_ControlerActionsCallbackInterface;
    private readonly InputAction m_Controler_Move;
    private readonly InputAction m_Controler_RotateSpells;
    private readonly InputAction m_Controler_UseSpells;
    private readonly InputAction m_Controler_ShowSpells;
    private readonly InputAction m_Controler_Jump;
    private readonly InputAction m_Controler_ChangeCharacter;
    private readonly InputAction m_Controler_Pause;
    public struct ControlerActions
    {
        private @ControlsBan m_Wrapper;
        public ControlerActions(@ControlsBan wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controler_Move;
        public InputAction @RotateSpells => m_Wrapper.m_Controler_RotateSpells;
        public InputAction @UseSpells => m_Wrapper.m_Controler_UseSpells;
        public InputAction @ShowSpells => m_Wrapper.m_Controler_ShowSpells;
        public InputAction @Jump => m_Wrapper.m_Controler_Jump;
        public InputAction @ChangeCharacter => m_Wrapper.m_Controler_ChangeCharacter;
        public InputAction @Pause => m_Wrapper.m_Controler_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Controler; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlerActions set) { return set.Get(); }
        public void SetCallbacks(IControlerActions instance)
        {
            if (m_Wrapper.m_ControlerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnMove;
                @RotateSpells.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnRotateSpells;
                @RotateSpells.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnRotateSpells;
                @RotateSpells.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnRotateSpells;
                @UseSpells.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnUseSpells;
                @UseSpells.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnUseSpells;
                @UseSpells.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnUseSpells;
                @ShowSpells.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
                @ShowSpells.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
                @ShowSpells.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
                @Jump.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnJump;
                @ChangeCharacter.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnChangeCharacter;
                @ChangeCharacter.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnChangeCharacter;
                @ChangeCharacter.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnChangeCharacter;
                @Pause.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ControlerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RotateSpells.started += instance.OnRotateSpells;
                @RotateSpells.performed += instance.OnRotateSpells;
                @RotateSpells.canceled += instance.OnRotateSpells;
                @UseSpells.started += instance.OnUseSpells;
                @UseSpells.performed += instance.OnUseSpells;
                @UseSpells.canceled += instance.OnUseSpells;
                @ShowSpells.started += instance.OnShowSpells;
                @ShowSpells.performed += instance.OnShowSpells;
                @ShowSpells.canceled += instance.OnShowSpells;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ChangeCharacter.started += instance.OnChangeCharacter;
                @ChangeCharacter.performed += instance.OnChangeCharacter;
                @ChangeCharacter.canceled += instance.OnChangeCharacter;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ControlerActions @Controler => new ControlerActions(this);
    private int m_Controller1SchemeIndex = -1;
    public InputControlScheme Controller1Scheme
    {
        get
        {
            if (m_Controller1SchemeIndex == -1) m_Controller1SchemeIndex = asset.FindControlSchemeIndex("Controller 1");
            return asset.controlSchemes[m_Controller1SchemeIndex];
        }
    }
    public interface IDebugActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotateSpells(InputAction.CallbackContext context);
        void OnShowSpells(InputAction.CallbackContext context);
    }
    public interface IControlerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotateSpells(InputAction.CallbackContext context);
        void OnUseSpells(InputAction.CallbackContext context);
        void OnShowSpells(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnChangeCharacter(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
