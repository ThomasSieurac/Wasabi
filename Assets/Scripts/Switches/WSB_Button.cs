using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class WSB_Button : MonoBehaviour
{
    [SerializeField] InputActionAsset inputBan = null;
    [SerializeField] InputActionAsset inputLux = null;

    [SerializeField] bool active = false;
    [SerializeField, Min(.01f)] float duration = 1;
    [SerializeField] UnityEvent onActivate = null;
    [SerializeField] UnityEvent onDeactivate = null;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = active ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, .2f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If ban enter this trigger, its Use action is bound to the Interact method
        if (collision.GetComponent<WSB_Ban>())
            inputBan.FindAction("Use").performed += Interact;

        // If lux enter this trigger, its Use action is bound to the Interact method
        if (collision.GetComponent<WSB_Lux>())
            inputLux.FindAction("Use").performed += Interact;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If ban exits this trigger, its Interact method is unbound from the Use action
        if (collision.GetComponent<WSB_Ban>())
            inputBan.FindAction("Use").performed -= Interact;

        // If lux exits this trigger, its Interact method is unbound from the Use action
        if (collision.GetComponent<WSB_Lux>())
            inputLux.FindAction("Use").performed -= Interact;
    }

    void Interact(InputAction.CallbackContext obj)
    {
        // Check if the button isn't already active
        if (!active)
        {
            // Activates the button, invoke the event and start the delay for the deactivation
            active = true;
            onActivate?.Invoke();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        // Wait for duration and reset
        yield return new WaitForSeconds(duration);
        onDeactivate?.Invoke();
        active = false;
    }
}
