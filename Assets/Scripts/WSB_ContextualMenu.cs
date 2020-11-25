using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_ContextualMenu : MonoBehaviour
{

    [SerializeField] GameObject toShow = null;
    int playersIn = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Player>())
        {
            playersIn++;
            Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Player>())
        {
            playersIn--;
            if(playersIn == 0)
                Hide();
        }
    }

    void Show()
    {
        if (toShow)
            toShow.SetActive(true);
    }

    void Hide()
    {
        if (toShow)
            toShow.SetActive(false);
    }


}
