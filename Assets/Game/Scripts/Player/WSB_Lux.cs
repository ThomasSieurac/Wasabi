using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WSB_Lux : WSB_Player
{
    public static WSB_Lux I { get; private set; }

    [SerializeField] float range = 5;
    [SerializeField] LayerMask potLayer = 0;
    [SerializeField] LayerMask shrinkLayer = 0;

    [SerializeField] WSB_Spells spells = null;

    #region Spell Charges
    [SerializeField] int maxTrampolineCharges = 10;
    [SerializeField] int maxCarnivoreCharges = 10;
    [SerializeField] int maxBridgeCharges = 10;
    [SerializeField] int maxLadderCharges = 10;

    int trampolineCharges = 10;
    int carnivoreCharges = 10;
    int bridgeCharges = 10;
    int ladderCharges = 10;
    #endregion


    [SerializeField] float shrinkSpeed = 10;
    [SerializeField] GameObject render = null;
    bool shrinked = false;
    Coroutine shrink = null;
    Coroutine unshrink = null;

    Vector2 startSize = Vector2.zero;
    Vector3 startRenderSize = Vector3.zero;

    // Populate the Instance of this script
    private void Awake()
    {
        I = this;
    }

    // Set default calues to charges and adds custom update in game global update
    public override void Start()
    {
        WSB_GameManager.OnUpdate += MyUpdate;
        startSize = collider.size;
        startRenderSize = render.transform.localScale;
        bridgeCharges = maxBridgeCharges;
        trampolineCharges = maxTrampolineCharges;
        ladderCharges = maxLadderCharges;
        carnivoreCharges = maxCarnivoreCharges;
        spells.UpdateChargesUI(/*SpellType.Bridge,*/ bridgeCharges.ToString());
        spells.UpdateChargesUI(/*SpellType.Trampoline,*/ trampolineCharges.ToString());
        spells.UpdateChargesUI(/*SpellType.Ladder,*/ ladderCharges.ToString());
        spells.UpdateChargesUI(/*SpellType.Carnivore,*/ carnivoreCharges.ToString());
    }


    public override void Update()
    {
        // Has to be here and empty to override Unity update and use MyUpdate below
    }

    // Update called on bound event
    void MyUpdate()
    {
        base.Update();
    }

    public override void UseSpell(string _s)
    {
        base.UseSpell(_s);

        // Exit if game paused
        if (WSB_GameManager.Paused)
            return;

        // Search for pot in corresponding direction
        RaycastHit2D _hit = Physics2D.BoxCast(transform.position, collider.size, 0, isRight ? Vector2.right : Vector2.left, range, potLayer);
        //RaycastHit2D _hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - (shrinked ? .4f : .8f)), isRight ? Vector2.right : Vector2.left, range, potLayer);

        if(_hit)
        {
            WSB_Pot _pot = _hit.transform.GetComponent<WSB_Pot>();

            // Exist if WSB_Pot doesn't exist
            if (!_pot)
                return;


            // Switch on the given string to find the corresponding seed to grow
            if (_s == "Trampoline" && trampolineCharges > 0) 
                Trampoline(_pot);

            else if (_s == "Bridge" && bridgeCharges > 0) 
                Bridge(_pot);

            else if (_s == "Ladder" && ladderCharges > 0) 
                Ladder(_pot);

            else if (_s == "Carnivore" && carnivoreCharges > 0) 
                Carnivore(_pot);

            else 
                _pot.BreakSeed();
        }

    }

    public void RechargeSeed(string _s)
    {
        // Switch on given string to find the corresponding charges to increase if not already full and updates corresponding UI
        if (_s == "Trampoline" && trampolineCharges < maxTrampolineCharges)
        {
            trampolineCharges++;
            spells.UpdateChargesUI(/*SpellType.Trampoline,*/ trampolineCharges.ToString());
            spells.UpdateEmptyCharges(/*SpellType.Trampoline,*/ 1);
        }
        else if (_s == "Bridge" && bridgeCharges < maxBridgeCharges)
        {
            bridgeCharges++;
            spells.UpdateChargesUI(/*SpellType.Bridge,*/ bridgeCharges.ToString());
            spells.UpdateEmptyCharges(/*SpellType.Bridge,*/ 1);
        }
        else if (_s == "Ladder" && ladderCharges < maxLadderCharges)
        {
            ladderCharges++;
            spells.UpdateChargesUI(/*SpellType.Ladder,*/ ladderCharges.ToString());
            spells.UpdateEmptyCharges(/*SpellType.Ladder,*/ 1);
        }
        else if (_s == "Carnivore" && carnivoreCharges < maxCarnivoreCharges)
        {
            carnivoreCharges++;
            spells.UpdateChargesUI(/*SpellType.Carnivore,*/ carnivoreCharges.ToString());
            spells.UpdateEmptyCharges(/*SpellType.Carnivore,*/ 1);
        }
    }

    public bool Shrink()
    {
        StopJump();
        if (shrinked)
        {
            shrinked = false;
            AddSpeedCoef(2);
            if(shrink != null)
            {
                StopCoroutine(shrink);
                shrink = null;
            }
            unshrink = StartCoroutine(UnshrinkCoroutine());
            return false;
        }
        else
        {
            RemoveSpeedCoef(2);
            shrinked = true;
            if(unshrink != null)
            {
                StopCoroutine(unshrink);
                unshrink = null;
            }
            shrink = StartCoroutine(ShrinkCoroutine());
            return true;
        }
    }

    IEnumerator ShrinkCoroutine()
    {
        // Reduce size to half of the start's
        while (collider.size != startSize / 2)
        {
            collider.size = Vector2.MoveTowards(collider.size, startSize / 2, Time.deltaTime * shrinkSpeed);
            render.transform.localScale = Vector3.MoveTowards(render.transform.localScale, startRenderSize / 2, Time.deltaTime * shrinkSpeed);
            yield return new WaitForEndOfFrame();
        }
        shrink = null;
    }

    IEnumerator UnshrinkCoroutine()
    {
        // Checks above behind if there is a roof, loops until there isn't anymore
        while (Physics2D.Raycast(transform.position + Vector3.right, Vector2.up, 2, shrinkLayer) || Physics2D.Raycast(transform.position + Vector3.left, Vector2.up, 2, shrinkLayer))
            yield return new WaitForSeconds(.1f);

        // Increase size back to the stocked start size
        while (collider.size != startSize)
        {
            collider.size = Vector2.MoveTowards(collider.size, startSize, Time.deltaTime * shrinkSpeed);
            render.transform.localScale = Vector3.MoveTowards(render.transform.localScale, startRenderSize, Time.deltaTime * shrinkSpeed);
            yield return new WaitForEndOfFrame();
        }
        unshrink = null;
    }

    void Trampoline(WSB_Pot _pot)
    {
        // Exit if growing a seed isn't possible
        if (!_pot.GrowSeed("Trampoline"))
            return;

        // Reduce trampoline charges and update corresponding UI
        trampolineCharges--;
        spells.UpdateChargesUI(/*SpellType.Trampoline,*/ trampolineCharges.ToString());
        if(trampolineCharges == 0)
            spells.UpdateEmptyCharges(/*SpellType.Trampoline,*/ 0);
    }

    void Carnivore(WSB_Pot _pot)
    {
        // Exit if growing a seed isn't possible
        if (!_pot.GrowSeed("Carnivore"))
            return;

        // Reduce carnivore charges and update corresponding UI
        carnivoreCharges--;
        spells.UpdateChargesUI(/*SpellType.Carnivore,*/ carnivoreCharges.ToString());
        if(carnivoreCharges == 0)
            spells.UpdateEmptyCharges(/*SpellType.Carnivore,*/ 0);
    }

    void Bridge(WSB_Pot _pot)
    {
        // Exit if growing a seed isn't possible
        if (!_pot.GrowSeed("Bridge"))
            return;

        // Deploy bridge and gives it the direction it needs to grow
        _pot.GrownSeed.GetComponent<WSB_Bridge>().StartCoroutine(_pot.GrownSeed.GetComponent<WSB_Bridge>().DeployBridge(transform.position.x < _pot.transform.position.x));

        // Reduce bridge charges and update corresponding UI
        bridgeCharges--;
        spells.UpdateChargesUI(/*SpellType.Bridge,*/ bridgeCharges.ToString());
        if (bridgeCharges == 0)
            spells.UpdateEmptyCharges(/*SpellType.Bridge,*/ 0);
    }

    void Ladder(WSB_Pot _pot)
    {
        // Exit if growing a seed isn't possible
        if (!_pot.GrowSeed("Ladder"))
            return;

        // Reduce ladder charges and update corresponding UI
        ladderCharges--;
        spells.UpdateChargesUI(/*SpellType.Ladder,*/ ladderCharges.ToString());
        if (ladderCharges == 0)
            spells.UpdateEmptyCharges(/*SpellType.Ladder,*/ 0);
    }
}
