using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_MovingPlateform : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsOn = new List<GameObject>();
    [SerializeField] Vector3 lastFramePos = Vector3.zero;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.transform.GetComponent<WSB_Player>() || collision.transform.GetComponent<WSB_Movable>()) && !objectsOn.Contains(collision.gameObject))
            objectsOn.Add(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (objectsOn.Contains(collision.gameObject))
            objectsOn.Remove(collision.gameObject);
    }

    private void Start()
    {
        lastFramePos = transform.position;
    }

    void Update()
    {
        Vector3 _movement = transform.position - lastFramePos;
        for (int i = 0; i < objectsOn.Count; i++)
        {
            if (objectsOn[i].GetComponent<WSB_Player>())
                objectsOn[i].GetComponent<WSB_Player>().AddForce(_movement);
            else if (objectsOn[i].GetComponent<WSB_Movable>())
                objectsOn[i].GetComponent<WSB_Movable>().AddForce(_movement);
        }

        lastFramePos = transform.position;
    }
}
