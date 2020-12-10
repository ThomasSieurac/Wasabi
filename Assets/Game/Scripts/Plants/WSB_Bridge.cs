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
        // Gets needed components if not set.
        // Throw errors if not found them destroy itself
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

        // Loop until bridge has reached its destination
        while (transform.localScale != new Vector3(maxLength, transform.localScale.y, 1) && (Vector2)transform.position != new Vector2(_pos.x + (_right ? maxLength - 1 : -maxLength - 1) / 2, _pos.y))
        {
            // Hold if the game is paused
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            yield return new WaitForEndOfFrame();

            // Grow the scale of the bridge in the given direction
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(maxLength, transform.localScale.y, 1), Time.deltaTime * growSpeed);
            // Offset the position based on the growing scale and given direction
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_pos.x + (_right ? maxLength - 1 : -maxLength - 1) / 2, _pos.y), Time.deltaTime * growSpeed);

            // Checks if the bridge hits something and stops to grow if an found
            List<RaycastHit2D> _hit = new List<RaycastHit2D>();
            if (bridgeCollider.Cast(Vector2.zero, stopLayer, _hit) > 0)
                StopAllCoroutines();
        }
    }
}
