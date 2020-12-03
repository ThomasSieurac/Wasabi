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
        // Checks owner var and try to populate it from parent, destroy itself if not found
        if (!owner) owner = GetComponentInParent<WSB_Player>();
        if(!owner)
        {
            Debug.LogError($"Erreur, component Wsb_Player manquant sur {transform.name} parent");
            Destroy(this);
        }

        // Populate allSpells list if not correctly done
        for (int i = 0; i < 12; i++)
            if (!allSpells[i])
                allSpells[i] = transform.GetChild(i).GetChild(0).gameObject;

        // Disable each spell and activates the top ones
        for (int i = 0; i < 12; i++)
        {
            allSpells[i].SetActive(false);
            if (allSpells[i].transform.position.y > transform.position.y + .1f)
                allSpells[i].SetActive(true);
        }

        // Disable all spells if the bool isn't active
        if (!active)
            allSpells.ToList().ForEach(_g => _g.SetActive(false));

        // Find the top spell and keep it enable
        int _index = 0;
        float _height = allSpells[0].transform.position.y;
        for (int i = 1; i < allSpells.Length; i++)
        {
            // Replace the index and height if the current checked spell is higher
            if (allSpells[i].transform.position.y > _height)
            {
                _height = allSpells[i].transform.position.y;
                _index = i;
            }
        }
        // Activates the highest spell
        allSpells[_index].SetActive(true);
    }

    public void ShowWheel(InputAction.CallbackContext _context)
    {
        // Exit if paused or input isn't started
        if (!_context.started || WSB_PlayTestManager.Paused)
            return;

        // Activates all spells
        allSpells.ToList().ForEach(_g => _g.SetActive(true));
        for (int i = 0; i < 12; i++)
        {
            // Keep active only the top five spells
            allSpells[i].SetActive(false);
            if (allSpells[i].transform.position.y > transform.position.y + .1f) 
                allSpells[i].SetActive(true);
        }

        // Set global active bool to true
        active = true;
    }

    public void HideWheel(InputAction.CallbackContext _context)
    {
        // Exist if paused or input isn't canceled
        if (!_context.canceled || WSB_PlayTestManager.Paused) 
            return;

        // Disable all spells
        allSpells.ToList().ForEach(_g => _g.SetActive(false));

        // Find the top spell and keep it enable
        int _index = 0;
        float _height = allSpells[0].transform.position.y;
        for (int i = 1; i < allSpells.Length; i++)
        {
            // Replace the index and height if the current checked spell is higher
            if (allSpells[i].transform.position.y > _height)
            {
                _height = allSpells[i].transform.position.y;
                _index = i;
            }
        }
        // Activates the highest spell
        allSpells[_index].SetActive(true);

        // Set global active bool to false
        active = false;
    }

    public void UseSpell(InputAction.CallbackContext _context)
    {
        // If input is canceled stop any current spell
        if (_context.canceled) 
            owner.StopSpell();

        // Exit if paused or input isn't started
        if (!_context.started || WSB_PlayTestManager.Paused) return;

        // Find the highest spell
        int _i = 0;
        float _y = allSpells[0].transform.position.y;
        for (int i = 1; i < allSpells.Length; i++)
        {
            if (allSpells[i].transform.position.y > _y)
            {
                _i = i;
                _y = allSpells[i].transform.position.y;
            }
        }
        // Tell owner to use spell called by the found spell's tag
        owner.UseSpell(allSpells[_i].tag);
    }

    public void RotateSpells(InputAction.CallbackContext _context)
    {
        // Exit if spells aren't active, input isn't started or game is paused
        if (!active || !_context.started || WSB_PlayTestManager.Paused)
            return;

        // Find in wich way to rotate the wheel
        bool _right = _context.ReadValue<float>() > 0 ? true : false;

        // Rotate the wheel by 360/12° in the way found
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - (_right ? 30 : -30));
        for (int i = 0; i < 12; i++)
        {
            allSpells[i].transform.eulerAngles = new Vector3(allSpells[i].transform.eulerAngles.x, allSpells[i].transform.eulerAngles.y, allSpells[i].transform.eulerAngles.z + (_right ? 30 : -30));

            // Disable the current spell and activates it if it is in the highest 5
            allSpells[i].SetActive(false);
            if (allSpells[i].transform.position.y > transform.position.y + .1f)
                allSpells[i].SetActive(true);
        }
    }


}
