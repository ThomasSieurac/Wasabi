using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WSB_Player : MonoBehaviour
{
    Controls controls = null;

    [SerializeField] bool isLux = true;

    float horizontalMovement = 0;

    private void OnEnable()
    {
        controls.Enable();
    }

    private void Awake()
    {
        controls = new Controls();
    }

    private void Start()
    {
        //if (isLux)
        //{
        //    controls.Player.MoveLux.performed += Move;
        //    controls.Player.MoveLux.Enable();
        //}
        //else
        //{
        //    controls.Player.MoveBan.performed += Move;
        //    controls.Player.MoveBan.Enable();
        //}
    }

    private void Update()
    {
        if(Mathf.Abs(horizontalMovement) > .1f) transform.position += (Vector3.right * horizontalMovement) * Time.deltaTime;
    }



    public void Move(InputAction.CallbackContext _context)
    {
        horizontalMovement = _context.ReadValue<float>();
    }





}
