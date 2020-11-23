using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Bridge : MonoBehaviour
{
    [SerializeField] float maxLength = 10;
    [SerializeField] float growSpeed = 5;
    [SerializeField] LayerMask stopLayer = 0;
    [SerializeField] BoxCollider2D bridgeCollider = null;


    private void Start()
    {
        if (!bridgeCollider) bridgeCollider = GetComponentInChildren<BoxCollider2D>();
        if (!bridgeCollider)
        {
            Debug.LogError($"Erreur, component BoxCollider2D manquant sur {this.name}'s children");
            Destroy(this);
        }
    }

    public IEnumerator DeployBridge(bool _right)
    {
        Vector2 _pos = transform.position;
        while ((Vector2)transform.localScale != new Vector2(maxLength, transform.localScale.y) && (Vector2)transform.position != new Vector2(_pos.x + (_right ? maxLength -1 : -maxLength -1) / 2, _pos.y))
        {
            while (WSB_PlayTestManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            yield return new WaitForEndOfFrame();

            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(maxLength, transform.localScale.y), Time.deltaTime * growSpeed);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_pos.x + (_right ? maxLength - 1 : -maxLength - 1) / 2 , _pos.y), Time.deltaTime * growSpeed);

            if (Physics2D.OverlapBox(new Vector2(transform.position.x + (_right ? bridgeCollider.size.x : -bridgeCollider.size.x), transform.position.y), Vector2.one, 0, stopLayer)) StopAllCoroutines();
        }
    }
}
