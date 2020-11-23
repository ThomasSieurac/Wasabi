// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/Controls Lux.inputactions'

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
            ""name"": ""Debug"",
            ""id"": ""b53390b1-26dc-4737-8195-7c3da98bd360"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""16434301-5d73-4477-ad14-8c957ee81dc5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate Spells"",
                    ""type"": ""Value"",
                    ""id"": ""ccbf410b-2e49-42bb-9d66-b57488bbfa79"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Show Spells"",
                    ""type"": ""Button"",
                    ""id"": ""4a360f5e-3587-4dfb-a27c-f1e9a5d22d9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""9f33260e-2533-40f5-aaf7-42f15c9912d2"",
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
                    ""id"": ""29071c4b-4718-444b-8dd2-aa074acb45dd"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""691ad44e-11d3-4838-a64d-f1ba252daea4"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6334c354-9501-4113-97ae-210c018d876a"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Show Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c7143a77-6d28-40f7-8557-a73c979fc74d"",
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
                    ""id"": ""2f2c2a42-ef10-4543-9298-c0a3255f7c20"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""73ae1c80-5281-47ba-84ff-90565ed020f1"",
                    ""path"": ""<Keyboard>/rightArrow"",
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
            ""id"": ""365cca32-05e1-478b-a731-a390aef03aa7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4ef44be5-84e2-4270-a730-17964cb44cb7"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6a06e1b1-3291-4b44-b6ec-cc495e88a976"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Show Spells"",
                    ""type"": ""Button"",
                    ""id"": ""d763e7bb-17a8-4f5c-b42f-1be3498c8c93"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Spells"",
                    ""type"": ""Button"",
                    ""id"": ""60b9c4e7-1138-4026-94ba-f8aebf4b5762"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate Spells"",
                    ""type"": ""Value"",
                    ""id"": ""b7fcb421-ede0-42d4-ae91-190e0ea25beb"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ada2943f-cabf-4376-925b-68523e117505"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Character"",
                    ""type"": ""Button"",
                    ""id"": ""478b4a37-52b5-4244-b57b-6af606e6996e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Shoulder"",
                    ""id"": ""3073d1e0-3368-4eaf-bd4b-b477b548e52b"",
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
                    ""id"": ""eb405f61-9890-49d1-8e23-35f1e384d5a1"",
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
                    ""id"": ""e8d591fc-f926-42a1-a0b0-89e7cdf7cb5b"",
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
                    ""id"": ""3fae8d50-74d6-4e6c-930a-0b7a2d94d4cd"",
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
                    ""id"": ""5d091285-44c2-474a-9828-31cbf98d2f5c"",
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
                    ""id"": ""9a860a4c-c2e1-4ff4-9c9b-e6846abe8ad6"",
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
                    ""id"": ""e2a737ba-c65c-43a3-8f8d-2827830a8ea5"",
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
                    ""id"": ""5010432a-c8a7-4348-b1d2-2380fc3640b2"",
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
                    ""id"": ""a51936cc-8907-4441-afc7-4483f3b42757"",
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
                    ""id"": ""0289b497-0a0d-4169-aff3-c4b7b24f9426"",
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
                    ""id"": ""a4d9e1fc-8b98-4ce2-ba78-11cf6a9b420f"",
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
                    ""id"": ""b431ffc3-efd0-4726-9769-e74eeb5f5679"",
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
                    ""id"": ""48e813cb-039a-468d-9f48-1905a8f319c2"",
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
                    ""id"": ""11c65281-043c-4483-b55f-645c91e549ba"",
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
            ""name"": ""Controller 2"",
            ""bindingGroup"": ""Controller 2"",
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
        m_Controler_Jump = m_Controler.FindAction("Jump", throwIfNotFound: true);
        m_Controler_ShowSpells = m_Controler.FindAction("Show Spells", throwIfNotFound: true);
        m_Controler_UseSpells = m_Controler.FindAction("Use Spells", throwIfNotFound: true);
        m_Controler_RotateSpells = m_Controler.FindAction("Rotate Spells", throwIfNotFound: true);
        m_Controler_Pause = m_Controler.FindAction("Pause", throwIfNotFound: true);
        m_Controler_ChangeCharacter = m_Controler.FindAction("Change Character", throwIfNotFound: true);
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
        private @ControlsLux m_Wrapper;
        public DebugActions(@ControlsLux wrapper) { m_Wrapper = wrapper; }
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
    private readonly InputAction m_Controler_Jump;
    private readonly InputAction m_Controler_ShowSpells;
    private readonly InputAction m_Controler_UseSpells;
    private readonly InputAction m_Controler_RotateSpells;
    private readonly InputAction m_Controler_Pause;
    private readonly InputAction m_Controler_ChangeCharacter;
    public struct ControlerActions
    {
        private @ControlsLux m_Wrapper;
        public ControlerActions(@ControlsLux wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controler_Move;
        public InputAction @Jump => m_Wrapper.m_Controler_Jump;
        public InputAction @ShowSpells => m_Wrapper.m_Controler_ShowSpells;
        public InputAction @UseSpells => m_Wrapper.m_Controler_UseSpells;
        public InputAction @RotateSpells => m_Wrapper.m_Controler_RotateSpells;
        public InputAction @Pause => m_Wrapper.m_Controler_Pause;
        public InputAction @ChangeCharacter => m_Wrapper.m_Controler_ChangeCharacter;
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
                @Jump.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnJump;
                @ShowSpells.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
                @ShowSpells.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
                @ShowSpells.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
                @UseSpells.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnUseSpells;
                @UseSpells.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnUseSpells;
                @UseSpells.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnUseSpells;
                @RotateSpells.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnRotateSpells;
                @RotateSpells.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnRotateSpells;
                @RotateSpells.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnRotateSpells;
                @Pause.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnPause;
                @ChangeCharacter.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnChangeCharacter;
                @ChangeCharacter.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnChangeCharacter;
                @ChangeCharacter.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnChangeCharacter;
            }
            m_Wrapper.m_ControlerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ShowSpells.started += instance.OnShowSpells;
                @ShowSpells.performed += instance.OnShowSpells;
                @ShowSpells.canceled += instance.OnShowSpells;
                @UseSpells.started += instance.OnUseSpells;
                @UseSpells.performed += instance.OnUseSpells;
                @UseSpells.canceled += instance.OnUseSpells;
                @RotateSpells.started += instance.OnRotateSpells;
                @RotateSpells.performed += instance.OnRotateSpells;
                @RotateSpells.canceled += instance.OnRotateSpells;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @ChangeCharacter.started += instance.OnChangeCharacter;
                @ChangeCharacter.performed += instance.OnChangeCharacter;
                @ChangeCharacter.canceled += instance.OnChangeCharacter;
            }
        }
    }
    public ControlerActions @Controler => new ControlerActions(this);
    private int m_Controller2SchemeIndex = -1;
    public InputControlScheme Controller2Scheme
    {
        get
        {
            if (m_Controller2SchemeIndex == -1) m_Controller2SchemeIndex = asset.FindControlSchemeIndex("Controller 2");
            return asset.controlSchemes[m_Controller2SchemeIndex];
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
        void OnJump(InputAction.CallbackContext context);
        void OnShowSpells(InputAction.CallbackContext context);
        void OnUseSpells(InputAction.CallbackContext context);
        void OnRotateSpells(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnChangeCharacter(InputAction.CallbackContext context);
    }
}
