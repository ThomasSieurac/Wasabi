using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WSB_Lux : WSB_Player
{
    public static WSB_Lux I { get; private set; }

    [SerializeField] float range = 5;
    [SerializeField] LayerMask potLayer = 0;

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
    [SerializeField] float shrinkDuration = 20;
    [SerializeField] GameObject render = null;

    Coroutine shrink = null;

    [SerializeField] List<TMP_Text> ladderTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> bridgeTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> trampolineTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> carnivoreTextCharges = new List<TMP_Text>();

    // Populate the Instance of this script
    protected override void Awake()
    {
        base.Awake();
        I = this;
    }

    // Set default calues to charges and adds custom update in game global update
    void Start()
    {
        WSB_PlayTestManager.OnUpdate += MyUpdate;
        bridgeCharges = maxBridgeCharges;
        trampolineCharges = maxTrampolineCharges;
        ladderCharges = maxLadderCharges;
        carnivoreCharges = maxCarnivoreCharges;
    }


    protected override void Update()
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
        if (WSB_PlayTestManager.Paused)
            return;

        // Search for pot in corresponding direction
        RaycastHit2D _hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .8f), isRight ? Vector2.right : Vector2.left, range, potLayer);

        if(_hit)
        {
            WSB_Pot _pot = _hit.transform.GetComponent<WSB_Pot>();

            // Exist if WSB_Pot doesn't exist
            if (!_pot)
                return;

            // Exit if growing a seed isn't possible
            if (!_pot.GrowSeed(_s))
                return;

            // Switch on the given string to find the corresponding seed to grow
            if (_s == "Trampoline" && trampolineCharges > 0) 
                Trampoline();

            else if (_s == "Bridge" && bridgeCharges > 0) 
                Bridge(_pot);

            else if (_s == "Ladder" && ladderCharges > 0) 
                Ladder();

            else if (_s == "Carnivore" && carnivoreCharges > 0) 
                Carnivore();
        }

    }

    public void RechargeSeed(string _s)
    {
        // Switch on given string to find the corresponding charges to increase if not already full and updates corresponding UI
        if (_s == "Trampoline" && trampolineCharges < maxTrampolineCharges)
        {
            trampolineCharges++;
            UpdateChargesUI(trampolineTextCharges, trampolineCharges.ToString());
        }
        else if (_s == "Bridge" && bridgeCharges < maxBridgeCharges)
        {
            bridgeCharges++;
            UpdateChargesUI(bridgeTextCharges, bridgeCharges.ToString());
        }
        else if (_s == "Ladder" && ladderCharges < maxLadderCharges)
        {
            ladderCharges++;
            UpdateChargesUI(ladderTextCharges, ladderCharges.ToString());
        }
        else if (_s == "Carnivore" && carnivoreCharges < maxCarnivoreCharges)
        {
            carnivoreCharges++;
            UpdateChargesUI(carnivoreTextCharges, carnivoreCharges.ToString());
        }
    }

    public bool Shrink()
    {
        // If a shrink has already been done, exit with return that shrink wasn't done
        if (shrink != null)
            return false;

        // Start a shrink and return that shrink was done
        shrink = StartCoroutine(DelayShrink());
        return true;
    }

    [SerializeField] LayerMask shrinkLayer = 0;

    IEnumerator DelayShrink()
    {
        // Stock start sizes
        Vector2 _startSize = Collider.size;
        Vector3 _startRenderSize = render.transform.localScale;

        // Reduce size to half of the start's
        while(Collider.size != _startSize/2)
        {
            Collider.size = Vector2.MoveTowards(Collider.size, _startSize / 2, Time.deltaTime * shrinkSpeed);
            render.transform.localScale = Vector3.MoveTowards(render.transform.localScale, _startRenderSize / 2, Time.deltaTime * shrinkSpeed);
            yield return new WaitForEndOfFrame();
        }

        // Wait for shrink duration
        yield return new WaitForSeconds(shrinkDuration);

        // Checks above behind if there is a roof, loops until there isn't anymore
        while (Physics2D.Raycast(transform.position + Vector3.right, Vector2.up, 2, shrinkLayer) || Physics2D.Raycast(transform.position + Vector3.left, Vector2.up, 2, shrinkLayer)) 
            yield return new WaitForSeconds(.1f);

        // Increase size back to the stocked start size
        while(Collider.size != _startSize)
        {
            Collider.size = Vector2.MoveTowards(Collider.size, _startSize, Time.deltaTime * shrinkSpeed);
            render.transform.localScale = Vector3.MoveTowards(render.transform.localScale, _startRenderSize, Time.deltaTime * shrinkSpeed);
            yield return new WaitForEndOfFrame();
        }

        shrink = null;
    }

    void Trampoline()
    {
        // Reduce trampoline charges and update corresponding UI
        trampolineCharges--;
        UpdateChargesUI(trampolineTextCharges, trampolineCharges.ToString());
    }

    void Carnivore()
    {
        // Reduce carnivore charges and update corresponding UI
        carnivoreCharges--;
        UpdateChargesUI(carnivoreTextCharges, carnivoreCharges.ToString());
    }

    void Bridge(WSB_Pot _pot)
    {
        // Deploy bridge and gives it the direction it needs to grow
        _pot.GrownSeed.GetComponent<WSB_Bridge>().StartCoroutine(_pot.GrownSeed.GetComponent<WSB_Bridge>().DeployBridge(transform.position.x < _pot.transform.position.x));

        // Reduce bridge charges and update corresponding UI
        bridgeCharges--;
        UpdateChargesUI(bridgeTextCharges, bridgeCharges.ToString());
    }

    void Ladder()
    {
        // Reduce ladder charges and update corresponding UI
        ladderCharges--;
        UpdateChargesUI(ladderTextCharges, ladderCharges.ToString());
    }

    void UpdateChargesUI(List<TMP_Text> _list, string _value)
    {
        // Sets text of each object in the list to the value given
        foreach (TMP_Text _txt in _list)
        {
            _txt.text = _value;
        }
    }
}
