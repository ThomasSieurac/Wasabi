using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WSB_EventOnDestroy : MonoBehaviour
{
    public UnityEvent CallBack = null;
    private void OnDestroy()
    {
        CallBack?.Invoke();
    }
}
