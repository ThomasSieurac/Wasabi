using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WSB_Player : MonoBehaviour
{
    float horizontalMovement = 0;
    float verticalMovement = 0;

    private void OnEnable()
    {
        //controls.Enable();
    }

    private void Awake()
    {
        //controls = new Controls();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(Mathf.Abs(horizontalMovement) > .1f) transform.position += (Vector3.right * horizontalMovement) * Time.deltaTime * 10;
        if(Mathf.Abs(verticalMovement) > .1f) transform.position += (Vector3.up * verticalMovement) * Time.deltaTime * 10;
    }



    public void Move(InputAction.CallbackContext _context)
    {
        if(_context.valueType == typeof(float))
            horizontalMovement = _context.ReadValue<float>();
        else if(_context.valueType == typeof(Vector2))
        {
            horizontalMovement = _context.ReadValue<Vector2>().x;
            verticalMovement = _context.ReadValue<Vector2>().y;
        }
    }





}
