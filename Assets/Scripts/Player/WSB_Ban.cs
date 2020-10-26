using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class WSB_Ban : WSB_Player
{

    #region Spell Charges
    [SerializeField] int maxEarthCharges = 10;
    [SerializeField] int maxShrinkCharges = 10;
    [SerializeField] int maxWindCharges = 10;
    [SerializeField] int maxLightCharges = 10;

    int earthCharges = 10;
    int shrinkCharges = 10;
    int windCharges = 10;
    int lightCharges = 10;
    #endregion
    #region Earth Spell
    [Header("Earth Spell"), Space, Space, SerializeField] GameObject earthZone = null;

    [SerializeField] int earthSize = 5;
    [SerializeField] float earthDuration = 20;
    [SerializeField] float earthChargeDelay = 10;

    Coroutine rechargeEarth = null;

    [SerializeField] LayerMask groundLayer = 0;
    #endregion
    #region Light Spell
    [Header("Earth Spell"), Space, Space, SerializeField] GameObject lightObject = null;

    [SerializeField] float lightDuration = 10;
    [SerializeField] float lightChargeDelay = 10;

    Coroutine rechargeLight = null;
    #endregion
    #region Shrink Spell

    #endregion
    #region Wind Spell
    [Header("Wind Spell"), Space, Space, SerializeField] float windRange = 5;
    [SerializeField] float windPower = 2;
    [SerializeField] float windMaxMass = 20;
    [SerializeField] float windChargeDelay = 10;

    Coroutine blowCoroutine = null;
    Coroutine rechargeWind = null;

    [SerializeField] LayerMask moveLayer = 0;

    #endregion

    [SerializeField] List<TMP_Text> windTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> earthTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> shrinkTextCharges = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> lightTextCharges = new List<TMP_Text>();


    void Start()
    {
        windCharges = maxWindCharges;
        earthCharges = maxEarthCharges;
        lightCharges = maxLightCharges;
        shrinkCharges = maxShrinkCharges;
    }

    protected override void Update()
    {
        base.Update();
    }


    public override void UseSpell(string _s)
    {
        if (_s == "Earth" && earthCharges > 0) Earth();
        else if (_s == "Light" && lightCharges > 0) Light();
        else if (_s == "Shrink" && shrinkCharges > 0) Shrink();
        else if (_s == "Wind" && windCharges > 0) Wind();
    }

    public override void StopSpell()
    {
        if (blowCoroutine != null)
        {
            StopCoroutine(blowCoroutine);
            if (rechargeWind == null) rechargeWind = StartCoroutine(RechargeWind());
        }
    }

    void Shrink()
    {
        /*
         * 
         * Rapeticir Lux
         * Coroutine Recharge
         * Coroutine Delay
         *  -> fin regrandir Lux si possible
         *      -> si pas possible répéter toutes les x secondes
         *  
         */
    }

    #region Earth
    void Earth()
    {
        for (int i = -earthSize; i < earthSize; i++)
        {
            RaycastHit2D[] _hits = Physics2D.RaycastAll(new Vector2(transform.position.x + i, transform.position.y), Vector2.down, transform.localScale.y + .5f, groundLayer);
            if(_hits.Length == 0)
            {
                SpawnEarth(false);
                return;
            }
        }
        SpawnEarth(true);
    }

    void SpawnEarth(bool _status)
    {
        if(_status)
        {
            // play good FX
            earthCharges--;
            UpdateChargesUI(earthTextCharges, earthCharges.ToString());
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y + .5f, groundLayer);
            GameObject _zdt = Instantiate(earthZone, _hit.point, Quaternion.identity);
            _zdt.transform.SetParent(_hit.transform);
            StartCoroutine(DelayEarth(_zdt));
        }
        else
        {
            // play bad FX
        }
    }

    IEnumerator DelayEarth(GameObject _ref)
    {
        yield return new WaitForSeconds(earthDuration);
        if (rechargeEarth == null) rechargeEarth = StartCoroutine(RechargeEarth());
        Destroy(_ref);
    }

    IEnumerator RechargeEarth()
    {
        yield return new WaitForSeconds(earthChargeDelay);
        earthCharges++;
        UpdateChargesUI(earthTextCharges, earthCharges.ToString());
        if (earthCharges < maxEarthCharges) rechargeEarth = StartCoroutine(RechargeEarth());
        else rechargeEarth = null;
    }
    #endregion

    #region Light
    void Light()
    {
        lightCharges--;
        UpdateChargesUI(lightTextCharges, lightCharges.ToString());
        GameObject _light = Instantiate(lightObject, transform.position, Quaternion.identity);
        StartCoroutine(MoveLight(_light, (Vector2)_light.transform.position + Vector2.up * 2));
        StartCoroutine(DelayLight(_light));
    }
    IEnumerator MoveLight(GameObject _light, Vector2 _target)
    {
        while(Vector2.Distance(_light.transform.position, _target) != 0)
        {
            _light.transform.position = Vector2.MoveTowards(_light.transform.position, _target, Time.deltaTime * 2);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator DelayLight(GameObject _ref)
    {
        yield return new WaitForSeconds(lightDuration);
        if (rechargeLight == null) rechargeLight = StartCoroutine(RechargeLight());
        Destroy(_ref);
    }

    IEnumerator RechargeLight()
    {
        yield return new WaitForSeconds(lightChargeDelay);
        lightCharges++;
        UpdateChargesUI(lightTextCharges, lightCharges.ToString()); 
        if (lightCharges < maxLightCharges) rechargeLight = StartCoroutine(RechargeLight());
        else rechargeLight = null;
    }
    #endregion

    #region Wind
    void Wind()
    {
        //deb = true;
        windCharges--;
        UpdateChargesUI(windTextCharges, windCharges.ToString());
        blowCoroutine = StartCoroutine(Blow());
    }

    IEnumerator RechargeWind()
    {
        yield return new WaitForSeconds(windChargeDelay);
        windCharges++;
        UpdateChargesUI(windTextCharges, windCharges.ToString());
        if (windCharges < maxWindCharges) rechargeWind = StartCoroutine(RechargeWind());
        else rechargeWind = null;
    }

    IEnumerator Blow()
    {
        Rigidbody2D _physics;
        while(true)
        {
            Collider2D[] _hits = Physics2D.OverlapCircleAll(transform.position, windRange, moveLayer);
            Collider2D _hit;
            for (int i = 0; i < _hits.Length; i++)
            {
                _hit = _hits[i];
                _physics = _hit.gameObject.GetComponent<Rigidbody2D>();
                // if(raycast(pos, dir(pos, _hits.pos)) pas gêné, blow
                if (_physics && _physics.mass < windMaxMass)
                {
                    _physics.AddForce(Vector2.up * (windPower - (Vector2.Distance(transform.position, _hit.transform.position) / 2))); // jsp
                }
            }
            yield return new WaitForEndOfFrame();
        }
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

// 所有 <-- kanji "propriété"