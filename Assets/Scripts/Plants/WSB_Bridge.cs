using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Bridge : MonoBehaviour
{
    [SerializeField] float maxLength = 10;
    [SerializeField] float growSpeed = 5;
    [SerializeField] LayerMask stopLayer = 0;
    [SerializeField] BoxCollider2D bridgeCollider = null;

    //bool _debugright = true;

    private void Start()
    {
        if (!bridgeCollider) bridgeCollider = GetComponent<BoxCollider2D>();
        if (!bridgeCollider)
        {
            Debug.LogError($"Erreur, component BoxCollider2D manquant sur {this.name}");
            Destroy(this);
        }
        //StartCoroutine(DeployBridge(_debugright));
    }

    public IEnumerator DeployBridge(bool _right)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            bridgeCollider.size = Vector2.MoveTowards(bridgeCollider.size, new Vector2(maxLength, bridgeCollider.size.y), Time.deltaTime * growSpeed);
            bridgeCollider.offset = Vector2.MoveTowards(bridgeCollider.offset, new Vector2(_right ? bridgeCollider.size.x / 2 : -bridgeCollider.size.x / 2, bridgeCollider.offset.y), Time.deltaTime * growSpeed);

            if (Physics2D.OverlapBox(new Vector2(transform.position.x + (_right ? bridgeCollider.size.x : -bridgeCollider.size.x), transform.position.y), Vector2.one, 0, stopLayer)) StopAllCoroutines();

            if (bridgeCollider.bounds.size.y == 10) StopAllCoroutines();
        }
    }
}
