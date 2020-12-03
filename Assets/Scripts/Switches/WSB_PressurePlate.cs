using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class WSB_PressurePlate : MonoBehaviour
{
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
        // Look for any RigidBody2D component on the collider that came
        if (collision.GetComponent<Rigidbody2D>())
        {
            // Invoke activate event if there wasn't already an object on
            if(objectsOn == 0)
                onActivate?.Invoke();

            // Add this object to the count
            objectsOn++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Look for any RigidBody2D component on the collider that came
        if (collision.GetComponent<Rigidbody2D>())
        {
            // Invoke deactivate event if there is not another object on
            if (objectsOn == 1)
                onDeactivate?.Invoke();

            // Remove this object from the count
            objectsOn--;
        }
    }
}
