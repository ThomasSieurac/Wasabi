using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_InteractiveElement : MonoBehaviour
{
    [SerializeField] Animator animator = null;

    public void ActivateAnimator() => animator.SetTrigger("Activate");

}
