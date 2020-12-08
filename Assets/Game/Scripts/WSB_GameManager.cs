using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;

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

        // Disable mouse interaction on main menu
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menu.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
    }

    Color baseColor = Color.red;
    [SerializeField] float discoDelay = 2;
    [SerializeField] TMPro.TMP_Text warning = null;
    [SerializeField] GameObject warningObj = null; 

    private void Update()
    {
        // Just messing around to make the warning disco
        if(menu.activeSelf && warningObj.activeSelf)
        {
            Color _c = warning.color;
            if (baseColor == Color.red)
            {
                _c.b = Mathf.MoveTowards(_c.b, 1, Time.deltaTime * discoDelay);
                if (_c.b == 1) baseColor = Color.magenta;
            }
            else if (baseColor == Color.magenta)
            {
                _c.r = Mathf.MoveTowards(_c.r, 0, Time.deltaTime * discoDelay);
                if (_c.r == 0) baseColor = Color.blue;
            }
            else if (baseColor == Color.blue)
            {
                _c.g = Mathf.MoveTowards(_c.g, 1, Time.deltaTime * discoDelay);
                if (_c.g == 1) baseColor = Color.cyan;
            }
            else if (baseColor == Color.cyan)
            {
                _c.b = Mathf.MoveTowards(_c.b, 0, Time.deltaTime * discoDelay);
                if (_c.b == 0) baseColor = Color.green;
            }
            else if (baseColor == Color.green)
            {
                _c.r = Mathf.MoveTowards(_c.r, 1, Time.deltaTime * discoDelay);
                if (_c.r == 1) baseColor = Color.yellow;
            }
            else if (baseColor == Color.yellow)
            {
                _c.g = Mathf.MoveTowards(_c.g, 0, Time.deltaTime * discoDelay);
                if (_c.g == 0) baseColor = Color.red;
            }
            warning.color = _c;
        }

        // Activates the warning if there is no gamepad connected
        warningObj.SetActive(Gamepad.all.Count == 0);

        // Invoke the main Update of the game if it is not paused
        if (!Paused)
            OnUpdate?.Invoke();
    }

    public static void SetDialogue(bool _state) => IsDialogue = _state;

    public void ChangeCharacter(InputAction.CallbackContext _ctx)
    {
        // Exit if the game is paused or input isn't started
        if (!_ctx.started || Paused)
            return;

        // Switch the PlayerInput if the game is in SinglePlayer mode
        if(singlePlayer)
        {
            inputBan.enabled = !inputBan.enabled;
            inputLux.enabled = !inputLux.enabled;
        }
    }

    public void Pause(InputAction.CallbackContext _ctx)
    {
        // If input isn't start exit
        if (!_ctx.started)
            return;

        // Inverse pause state
        Paused = !Paused;

        // If the game is paused, invoke event, show menu and disable mouse input on this menu
        if (Paused)
        {
            OnPause?.Invoke();
            menuPause.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
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

    public void StartGame(bool _singlePlayer)
    {
        // If there isn't enough gamepad detected for the selected gamemode exit
        if (Gamepad.all.Count == 0 || (_singlePlayer && Gamepad.all.Count != 1) || (!_singlePlayer && Gamepad.all.Count != 2))
            return;

        // Set gamemode
        singlePlayer = _singlePlayer;

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

        // Setup inputs to only one character
        if(singlePlayer)
        {
            inputBan.enabled = true;
            inputLux.enabled = false;
        }

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
