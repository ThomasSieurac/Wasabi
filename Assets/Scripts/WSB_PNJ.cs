using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WSB_PNJ : MonoBehaviour
{
    [SerializeField] InputActionAsset actionBan = null;
    [SerializeField] InputActionAsset actionLux = null;

    [SerializeField] WSB_Dialogue dialogue = null;

    int playersIn = 0;

    private void OnEnable()
    {
        actionBan.FindAction("Use").performed += StartDialogue;
        actionLux.FindAction("Use").performed += StartDialogue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Player>()) playersIn++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<WSB_Player>()) playersIn--;
        if(playersIn == 0)
            dialogue.gameObject.SetActive(false);
    }

    void StartDialogue(InputAction.CallbackContext obj)
    {
        if (!dialogue || playersIn == 0)
            return;
        if (dialogue.gameObject.activeSelf)
            dialogue.Skip(obj);
        else
            dialogue.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        actionBan.FindAction("Use").performed -= StartDialogue;
        actionLux.FindAction("Use").performed -= StartDialogue;
    }
}
