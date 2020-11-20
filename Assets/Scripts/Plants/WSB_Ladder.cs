using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Ladder : MonoBehaviour
{
    [SerializeField] float maxLength = 10;
    [SerializeField] float growSpeed = 5;
    [SerializeField] LayerMask stopLayer = 0;
    [SerializeField] BoxCollider2D ladderCollider = null;

    private void Start()
    {
        if (!ladderCollider) ladderCollider = GetComponent<BoxCollider2D>();
        if(!ladderCollider)
        {
            Debug.LogError($"Erreur, component BoxCollider2D manquant sur {this.name}");
            Destroy(this);
        }
        StartCoroutine(DeployLadder());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Player>())
            collision.GetComponent<WSB_Player>().CanClimb(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Player>())
            collision.GetComponent<WSB_Player>().CanClimb(false);
    }

    IEnumerator DeployLadder()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            ladderCollider.size = Vector2.MoveTowards(ladderCollider.size, new Vector2(ladderCollider.size.x, maxLength), Time.deltaTime * growSpeed);
            ladderCollider.offset = Vector2.MoveTowards(ladderCollider.offset, new Vector2(ladderCollider.offset.x, ladderCollider.size.y / 2), Time.deltaTime * growSpeed);

            if (Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + ladderCollider.size.y), Vector2.one, 0, stopLayer)) StopAllCoroutines();

            if (ladderCollider.bounds.size.y == 10) StopAllCoroutines();
        }
    }

}
