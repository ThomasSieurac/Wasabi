using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Ladder : MonoBehaviour
{
    //[SerializeField] float maxLength = 10;
    //[SerializeField] float growSpeed = 5;
    //[SerializeField] ContactFilter2D stopLayer = new ContactFilter2D();
    //[SerializeField] BoxCollider2D ladderCollider = null;

    //private void Start()
    //{
    //    // Gets needed components if not set.
    //    // Throw errors if not found them destroy itself
    //    if (!ladderCollider) ladderCollider = GetComponent<BoxCollider2D>();
    //    if(!ladderCollider)
    //    {
    //        Debug.LogError($"Erreur, component BoxCollider2D manquant sur {this.name}");
    //        Destroy(this);
    //    }
    //    StartCoroutine(DeployLadder());
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // Checks if collision is a player and tells it that climb is available
    //    if (collision.GetComponent<WSB_Player>())
    //        collision.GetComponent<WSB_Player>().CanClimb(true);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    // Checks if collision is a player and tells it that climb isn't available
    //    if (collision.GetComponent<WSB_Player>())
    //        collision.GetComponent<WSB_Player>().CanClimb(false);
    //}


    //IEnumerator DeployLadder()
    //{
    //    // Loop until ladder has reached its definite size
    //    while (true)
    //    {
    //        yield return new WaitForEndOfFrame();

    //        // Grow the scale of the ladder
    //        transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(transform.localScale.x, maxLength, .1f), Time.deltaTime * growSpeed);

    //        // Checks if the ladder has a roof above itself and stop if yes
    //        RaycastHit2D[] _hits = new RaycastHit2D[5];
            
    //        if (ladderCollider.Cast(Vector2.zero, stopLayer, _hits) > 0)
    //        {
    //            bool _hit = false;
    //            foreach (RaycastHit2D _col in _hits)
    //            {
    //                if (_col && _col.transform.gameObject != this.gameObject && _col.transform.gameObject != transform.parent.gameObject)
    //                    _hit = true;
    //            }
    //            if(_hit)
    //                StopAllCoroutines();
    //        }

    //        // Stop if the ladder had reached its max size
    //        if (ladderCollider.bounds.size.y == maxLength)
    //            StopAllCoroutines();
    //    }
    //}

}