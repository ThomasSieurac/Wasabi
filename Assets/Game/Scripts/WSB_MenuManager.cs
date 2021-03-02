using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WSB_MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject menuPause;
    [SerializeField] Button keyboard;
    [SerializeField] Button controller;
    [SerializeField] Button both;
    public static WSB_MenuManager I { get; private set; }

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        WSB_GameManager.OnPause += Pause;
        WSB_GameManager.OnResume += Resume;

        keyboard.onClick.AddListener(delegate() { WSB_GameManager.I.StartGame("Keyboard"); });
        controller.onClick.AddListener(delegate() { WSB_GameManager.I.StartGame("Controller"); });
        both.onClick.AddListener(delegate() { WSB_GameManager.I.StartGame("Both"); });

        // Select the first item in the menu
        EventSystem.current.SetSelectedGameObject(menu.GetComponentInChildren<Button>().gameObject);
    }


    void Pause()
    {
        menuPause.SetActive(true);
        EventSystem.current.SetSelectedGameObject(menuPause.GetComponentInChildren<Button>().gameObject);
    }

    void Resume()
    {
        menuPause.SetActive(false);
    }
}
