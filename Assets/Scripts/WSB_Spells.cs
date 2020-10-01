using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WSB_Spells : MonoBehaviour
{

    [SerializeField] GameObject[] allSpells = new GameObject[12];

    [SerializeField] bool isLeftReleased = true;
    [SerializeField] bool isRightReleased = true;

    private void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            if (!allSpells[i]) allSpells[i] = transform.GetChild(i).GetChild(0).gameObject;
        }
        for (int i = 0; i < 12; i++)
        {
            allSpells[i].SetActive(false);
            if (allSpells[i].transform.position.y > transform.position.y + .1f) allSpells[i].SetActive(true);
        }
    }

    public void ShowWheel()
    {

    }

    public void HideWheel()
    {

    }

    public void UseSpell()
    {

    }
    public void RotateSpells(InputAction.CallbackContext _context)
    {
        if (!_context.started) return;
        bool _right = _context.ReadValue<float>() > 0 ? true : false;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - (_right ? 30 : -30));
        for (int i = 0; i < 12; i++)
        {
            allSpells[i].transform.eulerAngles = new Vector3(allSpells[i].transform.eulerAngles.x, allSpells[i].transform.eulerAngles.y, allSpells[i].transform.eulerAngles.z + (_right ? 30 : -30));
            allSpells[i].SetActive(false);
            if (allSpells[i].transform.position.y > transform.position.y + .1f) allSpells[i].SetActive(true);
        }
    }


}
