using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Bridge : MonoBehaviour
{
    [SerializeField] float maxLength = 10;
    [SerializeField] float growSpeed = 5;
    [SerializeField] ContactFilter2D stopLayer = new ContactFilter2D();
    [SerializeField] BoxCollider2D bridgeCollider = null;


    private void Start()
    {
        if (!bridgeCollider) bridgeCollider = GetComponent<BoxCollider2D>();
        if (!bridgeCollider)
        {
            Debug.LogError($"Erreur, component BoxCollider2D manquant sur {this.name}");
            Destroy(this);
        }
    }

    public IEnumerator DeployBridge(bool _right)
    {
        Vector2 _pos = transform.position;
        while (transform.localScale != new Vector3(maxLength, transform.localScale.y, 1) && (Vector2)transform.position != new Vector2(_pos.x + (_right ? maxLength - 1 : -maxLength - 1) / 2, _pos.y)) 
        {
            while (WSB_PlayTestManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            yield return new WaitForEndOfFrame();

            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(maxLength, transform.localScale.y, 1), Time.deltaTime * growSpeed);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_pos.x + (_right ? maxLength - 1 : -maxLength - 1) / 2, _pos.y), Time.deltaTime * growSpeed);
            List<RaycastHit2D> _hit = new List<RaycastHit2D>();
            if (bridgeCollider.Cast(Vector2.zero, stopLayer, _hit) > 0) StopAllCoroutines();
            //if ((_hit =  Physics2D.OverlapBox(new Vector2(transform.position.x + (_right ? bridgeCollider.size.x : -bridgeCollider.size.x), transform.position.y), Vector2.one, 0, stopLayer)) && _hit.gameObject != transform.parent.gameObject) StopAllCoroutines();
        }
    }
}
