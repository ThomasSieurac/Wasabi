using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Trampoline : MonoBehaviour
{
    [SerializeField] float force = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Checks if collider is physics and if it is above this object
        if (collider.GetComponent<LG_Movable>() && collider.transform.position.y > transform.position.y)
        {
            // Search if this is a movable element and make it jump
            if (collider.GetComponent<LG_Movable>())
            {
                collider.GetComponent<LG_Movable>().StopVerticalForce();
                collider.GetComponent<LG_Movable>().AddForce(Vector2.up * force);
            }
        }
    }
}
