using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WSB_MainMenu : MonoBehaviour
{
    [SerializeField] MenuMode currentMode = MenuMode.Title;

    [SerializeField] GameObject titleScreen = null;
    [SerializeField] GameObject mainMenu = null;
    [SerializeField] GameObject options = null;
    [SerializeField] GameObject credits = null;
    [SerializeField] GameObject characterSelection = null;
    bool canSkipTitle;

    private void Start()
    {
        ShowTitleScreen();
    }

    private void Update()
    {
        if(currentMode == MenuMode.Title && canSkipTitle)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
                ShowMainMenu();

            if(Gamepad.all.Count == 1)
            {
                if(GamepadAnyButtonPressed(Gamepad.all[0]))
                    ShowMainMenu();
            }
            else if (Gamepad.all.Count == 2)
            {
                if (GamepadAnyButtonPressed(Gamepad.all[0]) || GamepadAnyButtonPressed(Gamepad.all[1]))
                    ShowMainMenu();
            }
        }
    }

    bool GamepadAnyButtonPressed(Gamepad _g)
    {
        return 
            _g.buttonEast.wasPressedThisFrame ||
            _g.buttonNorth.wasPressedThisFrame ||
            _g.buttonSouth.wasPressedThisFrame ||
            _g.buttonWest.wasPressedThisFrame ||

            _g.aButton.wasPressedThisFrame ||
            _g.bButton.wasPressedThisFrame ||
            _g.xButton.wasPressedThisFrame ||
            _g.yButton.wasPressedThisFrame ||

            _g.circleButton.wasPressedThisFrame ||
            _g.crossButton.wasPressedThisFrame ||
            _g.squareButton.wasPressedThisFrame ||
            _g.triangleButton.wasPressedThisFrame ||

            _g.leftStickButton.wasPressedThisFrame ||
            _g.rightStickButton.wasPressedThisFrame ||

            _g.selectButton.wasPressedThisFrame ||
            _g.startButton.wasPressedThisFrame ||
            
            _g.leftTrigger.wasPressedThisFrame ||
            _g.rightTrigger.wasPressedThisFrame ||
            _g.leftShoulder.wasPressedThisFrame ||
            _g.rightShoulder.wasPressedThisFrame ||
            
            _g.dpad.left.wasPressedThisFrame ||
            _g.dpad.right.wasPressedThisFrame ||
            _g.dpad.up.wasPressedThisFrame ||
            _g.dpad.down.wasPressedThisFrame
            ;
    }

    IEnumerator DelayTitle()
    {
        yield return new WaitForSeconds(.5f);
        canSkipTitle = true;
    }

    public void ShowMainMenu()
    {
        currentMode = MenuMode.Main;
        EventSystem.current.SetSelectedGameObject(mainMenu.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
        SwitchMenu(ref mainMenu);
    }
    public void ShowTitleScreen()
    {
        canSkipTitle = false;
        StartCoroutine(DelayTitle());
        currentMode = MenuMode.Title;
        SwitchMenu(ref titleScreen);
    }
    public void ShowOptions()
    {
        currentMode = MenuMode.Options;
        SwitchMenu(ref options);
    }
    public void ShowCredits()
    {
        currentMode = MenuMode.Credits;
        SwitchMenu(ref credits);
    }
    public void ShowCharacterSelection()
    {

        currentMode = MenuMode.Select;
        SwitchMenu(ref characterSelection);
    }

    void SwitchMenu(ref GameObject _go)
    {
        titleScreen.SetActive(false);
        mainMenu.SetActive(false);
        characterSelection.SetActive(false);
        credits.SetActive(false);
        options.SetActive(false);
        _go.SetActive(true);
    }


}

public enum MenuMode
{
    Title,
    Main,
    Options,
    Credits,
    Select
}