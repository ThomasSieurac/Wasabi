using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WSB_Lever : MonoBehaviour
{
    [SerializeField] bool active = false;
    [SerializeField] UnityEvent onActivate = null;
    [SerializeField] UnityEvent onDeactivate = null;

    private void OnDrawGizmos()
    {
        Gizmos.color = active ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, .2f);
    }

    public void Interact()
    {
        // Call activate event and inverse active bool
        if(active)
        {
            onDeactivate?.Invoke();
            active = false;
        }
        // Call deactivate event and inverse active bool
        else
        {
            onActivate?.Invoke();
            active = true;
        }
    }

}
