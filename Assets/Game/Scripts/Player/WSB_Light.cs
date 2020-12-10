using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Light : MonoBehaviour
{
    [SerializeField] float range = 5;
    RaycastHit2D[] hits;
    List<WSB_Pot> curedPots = new List<WSB_Pot>();

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(.7f, .2f, .2f, .4f);
        Gizmos.DrawSphere(transform.position, range);
    }

    void Update()
    {
        // Constantly checks around itself to find all objects in range
        hits = Physics2D.CircleCastAll(transform.position, range, Vector2.right);
        if(hits.Length > 0)
        {
            WSB_Pot _pot;
            foreach (RaycastHit2D _hit in hits)
            {
                // Checks if there is a pot found, if it is cursed, and heals it
                _pot = _hit.transform.GetComponent<WSB_Pot>();
                if(_pot && _pot.IsCursed)
                {
                    _pot.SetCurse(false);
                    curedPots.Add(_pot);
                }
            }
        }
    }

    // Reset all curses of all cured pots when light end
    private void OnDestroy()
    {
        foreach (WSB_Pot _pot in curedPots)
        {
            _pot.SetCurse(true);
        }
    }
}
