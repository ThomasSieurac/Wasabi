using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using TMPro;

public class WSB_Spells : MonoBehaviour
{

    [SerializeField] GameObject[] allSpells = new GameObject[12];
    [SerializeField] bool active = false;
    [SerializeField] WSB_Player owner = null;

    #region Spell Text Lists
    [SerializeField] List<TMP_Text> earthTexts = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> windTexts = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> lightTexts = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> shrinkTexts = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> ladderTexts = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> bridgeTexts = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> trampolineTexts = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> carnivoreTexts = new List<TMP_Text>();
    #endregion


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
        {
            if (!allSpells[i])
                allSpells[i] = transform.GetChild(i).gameObject;

            // Populates TMP_Texts lists based on the tags of each spells
            string _tag = allSpells[i].tag;
            switch (_tag)
            {
                case "Earth":
                    earthTexts.Add(allSpells[i].transform.GetChild(0).GetComponent<TMP_Text>());
                    break;
                case "Wind":
                    windTexts.Add(allSpells[i].transform.GetChild(0).GetComponent<TMP_Text>());
                    break;
                case "Shrink":
                    shrinkTexts.Add(allSpells[i].transform.GetChild(0).GetComponent<TMP_Text>());
                    break;
                case "Light":
                    lightTexts.Add(allSpells[i].transform.GetChild(0).GetComponent<TMP_Text>());
                    break;
                case "Ladder":
                    ladderTexts.Add(allSpells[i].transform.GetChild(0).GetComponent<TMP_Text>());
                    break;
                case "Bridge":
                    bridgeTexts.Add(allSpells[i].transform.GetChild(0).GetComponent<TMP_Text>());
                    break;
                case "Trampoline":
                    trampolineTexts.Add(allSpells[i].transform.GetChild(0).GetComponent<TMP_Text>());
                    break;
                case "Carnivore":
                    carnivoreTexts.Add(allSpells[i].transform.GetChild(0).GetComponent<TMP_Text>());
                    break;
            }
        }

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
        if (!_context.started || WSB_GameManager.Paused)
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
        if (!_context.canceled || WSB_GameManager.Paused) 
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
        if (!_context.started || WSB_GameManager.Paused) return;

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
        if (!active || !_context.started || WSB_GameManager.Paused)
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

    public void UpdateChargesUI(SpellType _type, string _value)
    {
        // Sets text of each object in the list to the value given
        switch (_type)
        {
            case SpellType.Earth:
                foreach (TMP_Text _txt in earthTexts)
                {
                    _txt.text = _value;
                }
                break;
            case SpellType.Wind:
                foreach (TMP_Text _txt in windTexts)
                {
                    _txt.text = _value;
                }
                break;
            case SpellType.Light:
                foreach (TMP_Text _txt in lightTexts)
                {
                    _txt.text = _value;
                }
                break;
            case SpellType.Shrink:
                foreach (TMP_Text _txt in shrinkTexts)
                {
                    _txt.text = _value;
                }
                break;
            case SpellType.Ladder:
                foreach (TMP_Text _txt in ladderTexts)
                {
                    _txt.text = _value;
                }
                break;
            case SpellType.Bridge:
                foreach (TMP_Text _txt in bridgeTexts)
                {
                    _txt.text = _value;
                }
                break;
            case SpellType.Trampoline:
                foreach (TMP_Text _txt in trampolineTexts)
                {
                    _txt.text = _value;
                }
                break;
            case SpellType.Carnivore:
                foreach (TMP_Text _txt in carnivoreTexts)
                {
                    _txt.text = _value;
                }
                break;
        }
    }

}

public enum SpellType
{
    Earth,
    Wind,
    Light,
    Shrink,
    Ladder,
    Bridge,
    Trampoline,
    Carnivore
}