using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_MovingPlateform2 : MonoBehaviour
{
    [SerializeField] Collider2D col = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<Nowhere.LG_Movable>())
        {
            collision.transform.GetComponent<Nowhere.LG_Movable>().SetOnMovingPlateform(true, col);
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Nowhere.LG_Movable>())
        {
            collision.transform.GetComponent<Nowhere.LG_Movable>().SetOnMovingPlateform(false, col);
            collision.transform.SetParent(null);
        }
    }
}
