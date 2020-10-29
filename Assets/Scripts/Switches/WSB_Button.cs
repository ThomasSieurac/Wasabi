using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WSB_Button : MonoBehaviour
{
    [SerializeField] bool active = false;
    [SerializeField, Min(.01f)] float duration = 1;
    [SerializeField] UnityEvent onActivate = null;

    private void OnDrawGizmos()
    {
        Gizmos.color = active ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position, .2f);
    }

    public void Interact()
    {
        if (!active)
        {
            onActivate?.Invoke();
            active = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(duration);
        active = false;
    }
}
