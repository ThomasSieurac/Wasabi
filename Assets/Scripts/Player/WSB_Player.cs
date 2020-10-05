using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WSB_Player : MonoBehaviour
{
    protected Rigidbody2D Physic = null;

    float _x = 0;

    private void Awake()
    {
        if(!Physic) Physic = GetComponent<Rigidbody2D>();
        if(!Physic)
        {
            Debug.LogError($"Erreur, component Rigidbody2D manquant sur {transform.name}");
            Destroy(this);
        }
    }

    protected virtual void Update()
    {
        transform.position += new Vector3(_x, 0, 0) * .25f;
    }


    public void Move(InputAction.CallbackContext _context)
    {
        if (_context.valueType != typeof(System.Single)) return;
        _x = _context.ReadValue<System.Single>();
    }

    public void Jump(InputAction.CallbackContext _context)
    {

    }

    public virtual void UseSpell(string _s)
    {

    }
    public virtual void StopSpell()
    {

    }


}
