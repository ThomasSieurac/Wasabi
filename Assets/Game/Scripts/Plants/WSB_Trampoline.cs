using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Trampoline : MonoBehaviour
{
    [SerializeField] float force = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Checks if collider is physics and if it is above this object
        if (collider.GetComponent<Rigidbody2D>() && collider.transform.position.y > transform.position.y)
        {
            // Search if this is a Player and make him jump
            if (collider.GetComponent<WSB_Player>())
                collider.GetComponent<WSB_Player>().TrampolineJump(Vector2.up * force);

            // Search if this is a movable element and make it jump
            else if (collider.GetComponent<WSB_Movable>())
            {
                collider.GetComponent<WSB_Movable>().StopVerticalForce();
                collider.GetComponent<WSB_Movable>().AddForce(Vector2.up * force);
            }
        }
    }
}
