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

    int playersIn = 0;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = active ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, .2f);
    }


    private void OnEnable()
    {
        inputBan.FindAction("Use").performed += Interact;
        inputLux.FindAction("Use").performed += Interact;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Player>()) playersIn++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Player>()) playersIn--;
    }

    void Interact(InputAction.CallbackContext obj)
    {
        if (!active && playersIn > 0)
        {
            active = true;
            onActivate?.Invoke();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(duration);
        active = false;
    }

    private void OnDisable()
    {
        inputBan.FindAction("Use").performed -= Interact;
        inputLux.FindAction("Use").performed -= Interact;
    }
}
