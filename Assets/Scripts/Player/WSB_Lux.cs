using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WSB_Lux : WSB_Player
{
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

    #region Trampoline Seed
    [Header("Trampoline Seed"), Space, Space, SerializeField] float trampolineChargeDelay = 10;

    Coroutine rechargeTrampoline = null;
    #endregion

    #region Carnivore Seed
    [Header("Carnivore Seed"), Space, Space, SerializeField]  float carnivoreChargeDelay = 10;

    Coroutine rechargeCarnivore = null;
    #endregion

    #region Ladder Seed
    [Header("Ladder Seed"), Space, Space, SerializeField] float ladderChargeDelay = 10;

    Coroutine rechargeLadder = null;
    #endregion

    #region Bridge Seed
    [Header("Bridge Seed"), Space, Space, SerializeField] float bridgeChargeDelay = 10;

    Coroutine rechargeBridge = null;
    #endregion


    [SerializeField] List<TMP_Text> ladderTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> bridgeTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> trampolineTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> carnivoreTextCharges = new List<TMP_Text>();


    void Start()
    {
        WSB_PlayTestManager.OnUpdate += MyUpdate;
        //WSB_PlayTestManager.OnUpdate += base.Update;
        bridgeCharges = maxBridgeCharges;
        trampolineCharges = maxTrampolineCharges;
        ladderCharges = maxLadderCharges;
        carnivoreCharges = maxCarnivoreCharges;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (isRight ? Vector2.right : Vector2.left) * range);
    }

    protected override void Update()
    {
        // leave empty
    }

    void MyUpdate()
    {
        base.Update();
    }

    public override void UseSpell(string _s)
    {
        if (WSB_PlayTestManager.Paused)
            return;

        RaycastHit2D _hit = Physics2D.Raycast(transform.position, isRight ? Vector2.right : Vector2.left, range, potLayer);

        if(_hit)
        {
            WSB_Pot _pot = _hit.transform.GetComponent<WSB_Pot>();
            if (!_pot) return;
            _pot.GrowSeed(_s);
            if (_s == "Trampoline" && trampolineCharges > 0) Trampoline();
            else if (_s == "Bridge" && bridgeCharges > 0) Bridge(_pot);
            else if (_s == "Ladder" && ladderCharges > 0) Ladder();
            else if (_s == "Carnivore" && carnivoreCharges > 0) Carnivore();
        }

    }

    #region Trampoline
    void Trampoline()
    {
        trampolineCharges--;
        if (rechargeTrampoline == null) StartCoroutine(RechargeTrampoline());
    }

    IEnumerator RechargeTrampoline()
    {
        yield return new WaitForSeconds(trampolineChargeDelay);
        trampolineCharges++;
        UpdateChargesUI(trampolineTextCharges, trampolineCharges.ToString());
        if (trampolineCharges < maxTrampolineCharges) rechargeTrampoline = StartCoroutine(RechargeTrampoline());
        else rechargeTrampoline = null;
    }
    #endregion

    #region Carnivore
    void Carnivore()
    {
        carnivoreCharges--;
        if (rechargeCarnivore == null) StartCoroutine(RechargeCarnivore());
    }

    IEnumerator RechargeCarnivore()
    {
        yield return new WaitForSeconds(carnivoreChargeDelay);
        carnivoreCharges++;
        UpdateChargesUI(carnivoreTextCharges, carnivoreCharges.ToString());
        if (carnivoreCharges < maxCarnivoreCharges) rechargeCarnivore = StartCoroutine(RechargeCarnivore());
        else rechargeCarnivore = null;
    }
    #endregion

    #region Bridge
    void Bridge(WSB_Pot _pot)
    {
        _pot.GrownSeed.GetComponent<WSB_Bridge>().StartCoroutine(_pot.GrownSeed.GetComponent<WSB_Bridge>().DeployBridge(transform.position.x < _pot.transform.position.x));
        bridgeCharges--;
        if (rechargeBridge == null) StartCoroutine(RechargeBridge());
    }

    IEnumerator RechargeBridge()
    {
        yield return new WaitForSeconds(bridgeChargeDelay);
        bridgeCharges++;
        UpdateChargesUI(bridgeTextCharges, bridgeCharges.ToString());
        if (bridgeCharges < maxBridgeCharges) rechargeBridge = StartCoroutine(RechargeBridge());
        else rechargeBridge = null;
    }
    #endregion

    #region Ladder
    void Ladder()
    {
        ladderCharges--;
        if(rechargeLadder == null) StartCoroutine(RechargeLadder());
    }

    IEnumerator RechargeLadder()
    {
        yield return new WaitForSeconds(ladderChargeDelay);
        ladderCharges++;
        UpdateChargesUI(ladderTextCharges, ladderCharges.ToString());
        if (ladderCharges < maxLadderCharges) rechargeLadder = StartCoroutine(RechargeLadder());
        else rechargeLadder = null;
    }
    #endregion

    void UpdateChargesUI(List<TMP_Text> _list, string _value)
    {
        foreach (TMP_Text _txt in _list)
        {
            _txt.text = _value;
        }
    }
}
