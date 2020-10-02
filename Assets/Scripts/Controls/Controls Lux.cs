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
                    ""expectedControlType"": ""Vector2"",
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
                    ""name"": ""2D Vector"",
                    ""id"": ""2d4f93d7-9505-46f3-86f8-6f38fd9675ae"",
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
                    ""id"": ""e74ccebd-53d8-4ef6-97ca-38f5fecdf995"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""95ef9fae-9a15-4738-9d33-1a01b283c13f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""37abba81-e0e1-4646-8ba4-5875f4f8474d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ac0769a5-ba5d-440c-80bf-af2bfd98bb15"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
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
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9cee702b-5edc-472c-9008-d70d4584ef05"",
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
                    ""id"": ""21a1332f-d21f-446f-a759-d8778cf27d91"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3743554a-9084-4100-ab9c-d970c67c01cc"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9aaffe9b-02ed-48fd-bbac-b3eaab9c5720"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b2e0b282-89de-4308-81c4-e0729c83a430"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_Move = m_Debug.FindAction("Move", throwIfNotFound: true);
        m_Debug_RotateSpells = m_Debug.FindAction("Rotate Spells", throwIfNotFound: true);
        m_Debug_ShowSpells = m_Debug.FindAction("Show Spells", throwIfNotFound: true);
        // Controler
        m_Controler = asset.FindActionMap("Controler", throwIfNotFound: true);
        m_Controler_Move = m_Controler.FindAction("Move", throwIfNotFound: true);
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
    public struct ControlerActions
    {
        private @ControlsLux m_Wrapper;
        public ControlerActions(@ControlsLux wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controler_Move;
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
            }
            m_Wrapper.m_ControlerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public ControlerActions @Controler => new ControlerActions(this);
    public interface IDebugActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotateSpells(InputAction.CallbackContext context);
        void OnShowSpells(InputAction.CallbackContext context);
    }
    public interface IControlerActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
