using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WSB_EventOnDestroy : MonoBehaviour
{
    [SerializeField] UnityEvent callBack = null;
    private void OnDestroy()
    {
        callBack.Invoke();
    }
}
