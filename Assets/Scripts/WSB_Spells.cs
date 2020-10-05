using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class WSB_Spells : MonoBehaviour
{

    [SerializeField] GameObject[] allSpells = new GameObject[12];
    [SerializeField] bool active = false;
    [SerializeField] WSB_Player owner = null;

    private void Awake()
    {
        if (!owner) owner = GetComponentInParent<WSB_Player>();
        if(!owner)
        {
            Debug.LogError($"Erreur, component Wsb_Player manquant sur {transform.name} parent");
            Destroy(this);
        }
        for (int i = 0; i < 12; i++)
        {
            if (!allSpells[i]) allSpells[i] = transform.GetChild(i).GetChild(0).gameObject;
        }
        for (int i = 0; i < 12; i++)
        {
            allSpells[i].SetActive(false);
            if (allSpells[i].transform.position.y > transform.position.y + .1f) allSpells[i].SetActive(true);
        }
        if (active)
        {
            allSpells.ToList().ForEach(_g => _g.SetActive(true));
            for (int i = 0; i < 12; i++)
            {
                allSpells[i].SetActive(false);
                if (allSpells[i].transform.position.y > transform.position.y + .1f) allSpells[i].SetActive(true);
            }
            active = true;
        }
        else
        {
            allSpells.ToList().ForEach(_g => _g.SetActive(false));
            active = false;
        }
    }

    public void ShowWheel(InputAction.CallbackContext _context)
    {
        if (!_context.started) return;
        allSpells.ToList().ForEach(_g => _g.SetActive(true));
        for (int i = 0; i < 12; i++)
        {
            allSpells[i].SetActive(false);
            if (allSpells[i].transform.position.y > transform.position.y + .1f) allSpells[i].SetActive(true);
        }
        active = true;
    }

    public void HideWheel(InputAction.CallbackContext _context)
    {
        if (!_context.canceled) return;
        allSpells.ToList().ForEach(_g => _g.SetActive(false));
        active = false;
    }

    public void UseSpell(InputAction.CallbackContext _context)
    {
        if (_context.canceled) owner.StopSpell();
        if (!_context.started || !active) return;
        for (int i = 0; i < allSpells.Length; i++)
        {
            if(allSpells[i].transform.localEulerAngles.z == 0)
            {
                owner.UseSpell(allSpells[i].tag);
                break;
            }
        }
    }

    public void RotateSpells(InputAction.CallbackContext _context)
    {
        if (!active || !_context.started) return;
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
