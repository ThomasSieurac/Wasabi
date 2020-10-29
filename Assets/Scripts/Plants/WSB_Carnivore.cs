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
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        while(true)
        {
            if (isEating)
            {
                yield return new WaitForSeconds(2);
            }
            else
            {
                Collider2D[] _hits = Physics2D.OverlapCircleAll(transform.position, range, eatLayer);
                if (_hits.Length > 0) StartCoroutine(Eat(_hits));
                yield return new WaitForSeconds(2);
            }
        }
    }

    IEnumerator Eat(Collider2D[] _hits)
    {
        isEating = true;
        for(int i = 0; i < _hits.Length; i++)
        {
            Destroy(_hits[i].gameObject);
            yield return new WaitForSeconds(eatDelay);
        }
        isEating = false;
    }
}
