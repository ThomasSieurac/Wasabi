using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;
using System.Linq;

public class WSB_GameManager : MonoBehaviour
{
    bool singlePlayer = true;

    [SerializeField] PlayerInput inputBan = null;
    [SerializeField] PlayerInput inputLux = null;

    [SerializeField] GameObject menu = null; 
    [SerializeField] GameObject menuPause = null; 
    public static bool Paused { get; private set; } = true;
    public static bool IsDialogue { get; private set; } = false;


    public static event Action OnUpdate = null;
    public static event Action OnPause = null;
    public static event Action OnResume = null;


    private void Start()
    {
        // Hide the mouse cursor
        Cursor.visible = false;

        // Get every Rigidbody in the scene and freeze them
        Rigidbody2D[] _physics = FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D _r in _physics)
        {
            _r.isKinematic = true;
            _r.velocity = Vector2.zero;
            _r.angularVelocity = 0;
        }

        InputSystem.onDeviceChange += DeviceChange;

        // Select the first item in the menu
        EventSystem.current.SetSelectedGameObject(menu.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
    }

    private void DeviceChange(InputDevice arg1, InputDeviceChange arg2)
    {
        if(arg2 == InputDeviceChange.Disconnected)
        {
            Paused = true;

            OnPause?.Invoke();
            menuPause.SetActive(true);
            EventSystem.current.SetSelectedGameObject(menuPause.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
        }
    }

    private void Update()
    {
        // Invoke the main Update of the game if it is not paused
        if (!Paused)
            OnUpdate?.Invoke();
    }

    public static void SetDialogue(bool _state) => IsDialogue = _state;

    public void Pause(InputAction.CallbackContext _ctx)
    {
        // If input isn't start exit
        if (!_ctx.started)
            return;

        // Inverse pause state
        Paused = !Paused;

        // If the game is paused, invoke event, show menu and select the first item in the menu
        if (Paused)
        {
            OnPause?.Invoke();
            menuPause.SetActive(true);
            EventSystem.current.SetSelectedGameObject(menuPause.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
        }
        else
            Resume();
    }

    public void Resume()
    {
        // Set Pause state to false, invoke resume event, hide pause menu
        Paused = false;
        OnResume?.Invoke();
        menuPause.SetActive(false);
    }

    public void SetBanController(bool _isBan)
    {
        isBanController = _isBan;
    }

    bool isBanController = true;

    public void StartGame(string _m)
    {
        switch (_m)
        {
            case "Controller":
                if (!WSB_InputManager.I.ChangeControllers(ControlsMode.Controller, isBanController)) return;
                break;
            case "Keyboard":
                if (!WSB_InputManager.I.ChangeControllers(ControlsMode.Keyboard, isBanController)) return;
                break;
            case "Both":
                if (!WSB_InputManager.I.ChangeControllers(ControlsMode.ControllerKeyboard, isBanController)) return;
                break;
            default:
                return;
        }

        // Get all the rigidbody in the scene and unfreeze them
        Rigidbody2D[] _physics = FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D _r in _physics)
        {
            if (_r.GetComponent<WSB_Player>() || _r.GetComponent<WSB_Movable>())
                continue;
            _r.isKinematic = false;
        }

        // Set Pause to false
        Paused = false;



        OnResume?.Invoke();

        // Hide menu
        menu.SetActive(false);
    }

    public void ReloadScene()
    {
        // Reset all the events and load PlayTest scene
        OnUpdate = null;
        OnPause = null;
        OnResume = null;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hogu_PlayTest-1");
    }

    public void QuitGame() => Application.Quit();

}
