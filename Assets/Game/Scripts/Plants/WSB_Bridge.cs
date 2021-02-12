using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Bridge : MonoBehaviour
{
    [SerializeField] float maxLength = 10;
    [SerializeField] float growSpeed = 5;
    [SerializeField] ContactFilter2D stopLayer = new ContactFilter2D();
    [SerializeField] BoxCollider2D bridgeCollider = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;

    private void Start()
    {
        // Gets needed components if not set.
        // Throw errors if not found them destroy itself
        if (!bridgeCollider) bridgeCollider = GetComponentInChildren<BoxCollider2D>();
        if (!bridgeCollider)
        {
            Debug.LogError($"Erreur, component BoxCollider2D manquant sur {this.name}");
            Destroy(this);
        }
    }

    public IEnumerator DeployBridge(bool _right)
    {
        Vector2 _pos = transform.position;

        if(_right)
        {
            //Debug.LogError(spriteRenderer.transform.position.x);
            spriteRenderer.gameObject.transform.localPosition = new Vector3(-spriteRenderer.transform.localPosition.x, spriteRenderer.transform.localPosition.y, spriteRenderer.transform.localPosition.z);
            spriteRenderer.flipX = true;
        }

        bridgeCollider.transform.localPosition = new Vector3(bridgeCollider.transform.localPosition.x + (_right ? .5f : -.5f), bridgeCollider.transform.localPosition.y, bridgeCollider.transform.localPosition.z);

        // Loop until bridge has reached its destination
        while (transform.localScale != new Vector3(maxLength, transform.localScale.y, 1) && (Vector2)transform.position != new Vector2(_pos.x + (_right ? maxLength - 1 : -maxLength - 1) / 2, _pos.y))
        {
            // Hold if the game is paused
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            yield return new WaitForEndOfFrame();

            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(maxLength, transform.localScale.y, 1), Time.deltaTime * growSpeed);

            // Checks if the bridge hits something and stops to grow if an found
            List<RaycastHit2D> _hit = new List<RaycastHit2D>();
            if (bridgeCollider.Cast(Vector2.zero, stopLayer, _hit) > 0)
                StopAllCoroutines();
        }
    }
}
