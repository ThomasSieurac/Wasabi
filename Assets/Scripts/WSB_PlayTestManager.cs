using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class WSB_PlayTestManager : MonoBehaviour
{
    [SerializeField] bool singlePlayer = true;

    //[SerializeField] WSB_Ban ban = null; 
    //[SerializeField] WSB_Lux lux = null;
    [SerializeField] PlayerInput inputBan = null;
    [SerializeField] PlayerInput inputLux = null;

    Gamepad[] gamepads = new Gamepad[2];

    bool banIs1 = false;

    public static bool Paused { get; private set; } = false;


    public static event Action OnUpdate = null;
    public static event Action OnPause = null;
    public static event Action OnResume = null;


    private void Start()
    {
        gamepads = Gamepad.all.ToArray();
        if(gamepads.Length == 0)
        {
            Debug.LogError("Controller manquant.");
            Destroy(this);
        }
        singlePlayer = gamepads.Length == 1;
        if (singlePlayer)
            inputBan.enabled = false;
    }

    private void Update()
    {
        if (!Paused)
            OnUpdate?.Invoke();
    }


    public void ChangeCharacter(InputAction.CallbackContext _ctx)
    {
        if (!_ctx.started)
            return;

        if(singlePlayer)
        {
            inputBan.enabled = !inputBan.enabled;
            inputLux.enabled = !inputLux.enabled;
        }
    }

    public void Pause(InputAction.CallbackContext _ctx)
    {
        if (_ctx.ReadValue<float>() != 1 || !_ctx.started) 
            return;
        Paused = !Paused;
        if (Paused)
            OnPause?.Invoke();
        else
            OnResume?.Invoke();
    }




}

/*
 * 
 * 
 * changer de persos
 *      enable / disable les scripts sur select  (faire en sorte que les deux players se contrôlent avec la même manette)
 * 
 * 
 * tutoriels
 *      déplacement
 *      pouvoirs
 *      changement de persos
 *      
 * 
 * reset de la salle
 * 
 * mode 1 joueur
 * mode 2 joueurs
 * 
 * 
 * 
 * 
 */
