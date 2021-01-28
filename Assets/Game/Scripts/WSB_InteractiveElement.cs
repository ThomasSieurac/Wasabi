using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_InteractiveElement : MonoBehaviour
{
    [SerializeField] List<Animator> animators = new List<Animator>();
    [SerializeField] bool isOneTimeUse = false;
    [SerializeField] bool isAnimationPlayOnTrigger = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAnimationPlayOnTrigger)
            ActivateAnimators();
    }

    public void ActivateAnimators()
    {
        for (int i = 0; i < animators.Count; i++)
        {
            animators[i].SetTrigger("Activate");
        }
        if (isOneTimeUse)
            Destroy(this.gameObject);
    }

}
