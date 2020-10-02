using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class WSB_Spells : MonoBehaviour
{

    [SerializeField] GameObject[] allSpells = new GameObject[12];
    [SerializeField] bool active = false;

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

    public void UseSpell()
    {
        int _i = 0;
        float _h = 0;
        for (int i = 1; i < allSpells.Length; i++)
        {
            if(allSpells[i].transform.position.y > _h)
            {
                _h = allSpells[i].transform.position.y;
                _i = i;
            }
        }
        // call la méthode sur le player qui prendrais en args le tag de allSpells[_i] (probablement "Pont" ou "Vent") et traîter là bas avec un retour bool pour décompter une charge ou non
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
