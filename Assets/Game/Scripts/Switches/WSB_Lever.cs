using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WSB_Lever : MonoBehaviour
{
    [SerializeField] InputActionAsset inputBan = null;
    [SerializeField] InputActionAsset inputLux = null;

    [SerializeField] bool active = false;
    [SerializeField] UnityEvent onActivate = null;
    [SerializeField] UnityEvent onDeactivate = null;

    [SerializeField] float cooldown = .2f;
    bool canPress = true;

    private void OnDrawGizmos()
    {
        Gizmos.color = active ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, .2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If ban enter this trigger, its Use action is bound to the Interact method
        if (collision.GetComponent<WSB_Ban>())
            inputBan.FindAction("Interact").performed += Interact;

        // If lux enter this trigger, its Use action is bound to the Interact method
        if (collision.GetComponent<WSB_Lux>())
            inputLux.FindAction("Interact").performed += Interact;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If ban exits this trigger, its Interact method is unbound from the Use action
        if (collision.GetComponent<WSB_Ban>())
            inputBan.FindAction("Interact").performed -= Interact;

        // If lux exits this trigger, its Interact method is unbound from the Use action
        if (collision.GetComponent<WSB_Lux>())
            inputLux.FindAction("Interact").performed -= Interact;
    }

    public void Interact(InputAction.CallbackContext _ctx)
    {
        // Call activate event and inverse active bool
        if(active && canPress)
        {
            onDeactivate?.Invoke();
            active = canPress = false;
            StartCoroutine(Cooldown());
        }
        // Call deactivate event and inverse active bool
        else if (canPress)
        {
            onActivate?.Invoke();
            active = true;
            canPress = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canPress = true;
    }
}
