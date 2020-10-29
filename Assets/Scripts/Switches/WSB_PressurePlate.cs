using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class WSB_PressurePlate : MonoBehaviour
{
    [SerializeField] float massNeeded = 10;

    [SerializeField] UnityEvent onActivate = null;
    [SerializeField] UnityEvent onDeactivate = null;

    int objectsOn = 0;

    private void Awake()
    {
        if (!GetComponent<Collider2D>())
        {
            Debug.LogError($"Collider 2D manquant sur {gameObject.name}");
            Destroy(this);
        }
        else if (!GetComponent<Collider2D>().isTrigger) GetComponent<Collider2D>().isTrigger = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() && collision.GetComponent<Rigidbody2D>().mass > massNeeded)
        {
            if(objectsOn == 0) onActivate?.Invoke();
            objectsOn++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() && collision.GetComponent<Rigidbody2D>().mass > massNeeded)
        {
            if(objectsOn == 1) onDeactivate?.Invoke();
            objectsOn--;
        }
    }
}
