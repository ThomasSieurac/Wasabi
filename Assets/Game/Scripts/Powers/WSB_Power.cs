using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Power : LG_Movable
{
    [SerializeField] Animator animator = null;
    [SerializeField] protected float range = 2;
    [SerializeField] protected bool isActive = true;

    public override void Start()
    {
        base.Start();

        if (!animator)
            TryGetComponent(out animator);

    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 2, .3f, .6f);
        Gizmos.DrawWireSphere((Vector2)transform.position, range);
    }


    public void ActivatePower()
    {
        isActive = false;

        if(animator)
            animator.SetTrigger("Grow");
    }

    public void DeactivatePower()
    {
        isActive = true;

        if (animator)
            animator.SetTrigger("Shrink");
    }
}
