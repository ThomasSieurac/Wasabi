using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WSB_PNJ : MonoBehaviour
{
    [SerializeField] InputActionAsset actionBan = null;
    [SerializeField] InputActionAsset actionLux = null;

    [SerializeField] WSB_Dialogue dialogue = null;

    bool banIn = false;
    bool luxIn = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Ban>())
        {
            //collision.GetComponent<WSB_Player>().IsDialogue = true;
            banIn = true;
            actionBan.FindAction("Use").performed += StartDialogue;
            //actionBan.FindAction("Jump").performed += StartDialogue;
        }
        if (collision.GetComponent<WSB_Lux>())
        {
            //collision.GetComponent<WSB_Player>().IsDialogue = true;
            luxIn = true;
            actionLux.FindAction("Use").performed += StartDialogue;
            //actionLux.FindAction("Jump").performed += StartDialogue;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Ban>())
        {
            //collision.GetComponent<WSB_Player>().IsDialogue = false;
            banIn = false;
            actionBan.FindAction("Use").performed -= StartDialogue;
            //actionBan.FindAction("Jump").performed -= StartDialogue;
        }
        if (collision.GetComponent<WSB_Lux>())
        {
            //collision.GetComponent<WSB_Player>().IsDialogue = false;
            luxIn = false;
            actionLux.FindAction("Use").performed -= StartDialogue;
            //actionLux.FindAction("Jump").performed -= StartDialogue;
        }
        if (!banIn && !luxIn)
        {
            dialogue.gameObject.SetActive(false);
            WSB_PlayTestManager.SetDialogue(false);
        }
    }

    void StartDialogue(InputAction.CallbackContext obj)
    {
        if (!dialogue || WSB_PlayTestManager.Paused)
            return;
        if (dialogue.gameObject.activeSelf)
            dialogue.Skip(obj);
        else if(!WSB_PlayTestManager.IsDialogue)
        {
            WSB_PlayTestManager.SetDialogue(true);
            dialogue.gameObject.SetActive(true);
        }
    }

}
