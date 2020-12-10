using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Carnivore : MonoBehaviour
{
    [SerializeField] float range = 5;
    [SerializeField] float eatDelay = 3;
    [SerializeField] LayerMask eatLayer = 0;
    bool isEating = false;

    private void Start()
    {
        // Start the main coroutine
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        // Will loop until the object is disabled or destroyed
        while(true)
        {
            // Buffer if the plant is eating something
            if (isEating)
            {
                yield return new WaitForSeconds(2);
            }

            else
            {
                // Search for element around range to eat
                Collider2D[] _hits = Physics2D.OverlapCircleAll(transform.position, range, eatLayer);
                // If found any, eat them
                if (_hits.Length > 0)
                    StartCoroutine(Eat(_hits));

                yield return new WaitForSeconds(2);
            }
        }
    }

    IEnumerator Eat(Collider2D[] _hits)
    {
        isEating = true;

        // Loop through found items to eat
        for(int i = 0; i < _hits.Length; i++)
        {
            // Destroy next item
            Destroy(_hits[i].gameObject);

            // Wait for given delay
            yield return new WaitForSeconds(eatDelay);
        }

        isEating = false;
    }
}
