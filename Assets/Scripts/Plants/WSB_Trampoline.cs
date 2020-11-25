using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Trampoline : MonoBehaviour
{
    [SerializeField] float force = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Rigidbody2D>() && collider.transform.position.y > (transform.position.y / 2))
        {
            if (collider.GetComponent<WSB_Player>())
                collider.GetComponent<WSB_Player>().TrampolineJump(Vector2.up * force);
            else
            {
                collider.GetComponent<Rigidbody2D>().velocity = new Vector2(collider.GetComponent<Rigidbody2D>().velocity.x, 0);
                collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (force * 50));
            }
        }
    }
}
