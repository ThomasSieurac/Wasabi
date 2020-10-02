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
                    ""expectedControlType"": ""Vector2"",
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
                    ""name"": ""2D Vector"",
                    ""id"": ""3ceecd84-d83d-4948-ad65-d2fc1a846969"",
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
                    ""id"": ""43a9ba6e-727e-4350-974b-3c1767da3f48"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6dca04be-40c6-477f-8e4f-19efff35086f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9634f397-7a0b-41b7-938e-8900740e3870"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ab7ab8f-fde9-4d33-b6d7-d547b0df2914"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
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
                    ""name"": ""Show Spells"",
                    ""type"": ""Button"",
                    ""id"": ""b13ba253-3de3-424e-b44d-a8b0f26546d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a1828413-dd4b-4bdb-9657-bae3be9dfecb"",
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
                    ""id"": ""42818de6-59dc-455a-9501-e519044d2a24"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""59409d05-685f-4a4b-8bd7-c0fc6cc5bfa8"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""06cd8167-a404-4086-804c-b164454b7dca"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""53e7b097-881a-4711-b6ec-f395754ff54e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
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
                    ""name"": ""Trigger"",
                    ""id"": ""5ca39b95-4d32-4872-9f10-b840e3d77ab0"",
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
                    ""id"": ""7b30f58c-2636-4907-95e8-595403a408ae"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Spells"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f7daa91e-89b9-4b62-8335-00649bb018df"",
                    ""path"": ""<Gamepad>/rightTrigger"",
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
        m_Controler_RotateSpells = m_Controler.FindAction("Rotate Spells", throwIfNotFound: true);
        m_Controler_ShowSpells = m_Controler.FindAction("Show Spells", throwIfNotFound: true);
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
    private readonly InputAction m_Controler_ShowSpells;
    public struct ControlerActions
    {
        private @ControlsBan m_Wrapper;
        public ControlerActions(@ControlsBan wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controler_Move;
        public InputAction @RotateSpells => m_Wrapper.m_Controler_RotateSpells;
        public InputAction @ShowSpells => m_Wrapper.m_Controler_ShowSpells;
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
                @ShowSpells.started -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
                @ShowSpells.performed -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
                @ShowSpells.canceled -= m_Wrapper.m_ControlerActionsCallbackInterface.OnShowSpells;
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
                @ShowSpells.started += instance.OnShowSpells;
                @ShowSpells.performed += instance.OnShowSpells;
                @ShowSpells.canceled += instance.OnShowSpells;
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
        void OnRotateSpells(InputAction.CallbackContext context);
        void OnShowSpells(InputAction.CallbackContext context);
    }
}
