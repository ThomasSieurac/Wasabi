using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_MovingPlateform : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsOn = new List<GameObject>();
    [SerializeField] Vector3 lastFramePos = Vector3.zero;
    public Vector3 Movement { get { return transform.position - lastFramePos; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!objectsOn.Contains(collision.gameObject) && collision.transform.GetComponent<WSB_Player>())
        {
            collision.transform.GetComponent<WSB_Player>().IsOnMovingPlateform = true;
            objectsOn.Add(collision.gameObject);
        }
        else if (!objectsOn.Contains(collision.gameObject) && collision.transform.GetComponent<WSB_Movable>())
        {
            collision.transform.GetComponent<WSB_Movable>().IsOnMovingPlateform = true;
            objectsOn.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (objectsOn.Contains(collision.gameObject))
        {
            StartCoroutine(DelayExit());
        }
    }


    private void Start()
    {
        lastFramePos = transform.position;
    }

    void Update()
    {
        for (int i = 0; i < objectsOn.Count; i++)
        {
            if(objectsOn[i].GetComponent<WSB_Player>())
                objectsOn[i].GetComponent<WSB_Player>().AddInstantForce(Movement);
            else if(objectsOn[i].GetComponent<WSB_Movable>())
                objectsOn[i].GetComponent<WSB_Movable>().AddInstantForce(Movement);
        }

        lastFramePos = transform.position;
    }

    IEnumerator DelayExit()
    {
        yield return new WaitForEndOfFrame();
        RaycastHit2D[] _hits = new RaycastHit2D[0];

        GetComponent<Collider2D>().Cast(Vector2.up, _hits);

        for (int i = 0; i < _hits.Length; i++)
        {
            if(!objectsOn.Contains(_hits[i].transform.gameObject))
            {
                if (_hits[i].transform.GetComponent<WSB_Player>())
                    _hits[i].transform.GetComponent<WSB_Player>().IsOnMovingPlateform = false;
                else if (_hits[i].transform.GetComponent<WSB_Movable>())
                    _hits[i].transform.GetComponent<WSB_Movable>().IsOnMovingPlateform = false;
            }
        }
    }
}
