using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class WSB_Ban : WSB_Player
{
    public static WSB_Ban I { get; private set; }

    [Header("Ban")]
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
    [Header("Light Spell"), Space, Space, SerializeField] GameObject lightObject = null;

    [SerializeField] float lightDuration = 10;
    [SerializeField] float lightChargeDelay = 10;

    Coroutine rechargeLight = null;
    #endregion
    #region Shrink Spell
    [Header("Shrink Spell"), SerializeField] float shrinkChargeDelay = 10;

    Coroutine rechargeShrink = null;
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

    // Sets instance of this object
    protected override void Awake()
    {
        base.Awake();
        I = this;
    }

    // Setup variables and events
    private void Start()
    {
        WSB_PlayTestManager.OnUpdate += MyUpdate;
        WSB_PlayTestManager.OnPause += StopSpell;
        windCharges = maxWindCharges;
        earthCharges = maxEarthCharges;
        lightCharges = maxLightCharges;
        shrinkCharges = maxShrinkCharges;
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
        if (WSB_PlayTestManager.Paused)
            return;

        // Search for corresponding spell and calls it
        if (_s == "Earth" && earthCharges > 0) 
            Earth();

        else if (_s == "Light" && lightCharges > 0) 
            Light();

        else if (_s == "Shrink" && shrinkCharges > 0) 
            Shrink();

        else if (_s == "Wind" && windCharges > 0) 
            Wind();
    }

    public override void StopSpell()
    {
        base.StopSpell();

        // Stops blow method if in use
        if (blowCoroutine != null)
        {
            StopCoroutine(blowCoroutine);
            if (rechargeWind == null) rechargeWind = StartCoroutine(RechargeWind());
        }
    }

    #region Shrink
    void Shrink()
    {
        // Checks if Ban has enough charges to do it
        if (shrinkCharges == 0)
            return;

        // Ask Lux to shrink, stop here if he can't
        if (!WSB_Lux.I.Shrink())
            return;

        // Reduce shrink charges and update corresponding UI
        shrinkCharges--;
        UpdateChargesUI(shrinkTextCharges, shrinkCharges.ToString());

        // Start coroutine to recharge the spell if not existing
        if (rechargeShrink != null)
            StopCoroutine(rechargeShrink);
        rechargeShrink = StartCoroutine(RechargeShrink());
    }

    IEnumerator RechargeShrink()
    {
        // Wait for shrinkchargesdelay
        yield return new WaitForSeconds(shrinkChargeDelay);

        // Increase shrink charges and update corresponding UI
        shrinkCharges++;
        UpdateChargesUI(shrinkTextCharges, shrinkCharges.ToString());

        // Checks if shrink charges are full, repeat this coroutine if not
        if (shrinkCharges < maxShrinkCharges)
            rechargeShrink = StartCoroutine(RechargeShrink());
        else
            rechargeShrink = null;
    }
    #endregion


    #region Earth
    void Earth()
    {
        // Checks if Ban has enough charges to do it
        if (earthCharges == 0)
            return;

        // Loops for x amount from player left to player right below him to find ground
        for (int i = -earthSize; i < earthSize; i++)
        {
            RaycastHit2D[] _hits = Physics2D.RaycastAll(new Vector2(transform.position.x + (i / 10f), transform.position.y), Vector2.down, 1.5f, groundLayer);
            if(_hits.Length != 0)
            {
                // If ground found, Earth if spawned and exit this method
                SpawnEarth(true);
                return;
            }
        }
        SpawnEarth(false);
    }

    void SpawnEarth(bool _status)
    {
        // If Earth did succesfully spawned
        if(_status)
        {
            // play good FX

            // Reduce earth charges and update corresponding UI
            earthCharges--;
            UpdateChargesUI(earthTextCharges, earthCharges.ToString());

            // Raycast below Ban to find ground and Instantiate Earth on this ground
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y + .5f, groundLayer);
            GameObject _zdt = Instantiate(earthZone, _hit.point, Quaternion.identity);

            // Set its parent so if the plateform moves, the Earth will move too
            _zdt.transform.SetParent(_hit.transform);

            // Start the coroutine of this Earth
            StartCoroutine(DelayEarth(_zdt));
        }
        
        // If Earth didn't succesfully spawned
        else
        {
            // play bad FX
        }
    }

    IEnumerator DelayEarth(GameObject _ref)
    {
        // Wait for earthduration
        yield return new WaitForSeconds(earthDuration);

        // Start recharge earth coroutine if not already started
        if (rechargeEarth == null)
            rechargeEarth = StartCoroutine(RechargeEarth());

        // Destroy this Earth when time is over
        Destroy(_ref);
    }

    IEnumerator RechargeEarth()
    {
        // Wait for earthchargedelay
        yield return new WaitForSeconds(earthChargeDelay);

        // Increase earth charges and update corresponding UI
        earthCharges++;
        UpdateChargesUI(earthTextCharges, earthCharges.ToString());

        // Checks if earth charges are full, repeat this coroutine if not
        if (earthCharges < maxEarthCharges) 
            rechargeEarth = StartCoroutine(RechargeEarth());
        else
            rechargeEarth = null;
    }
    #endregion

    #region Light
    void Light()
    {
        // Checks if Ban has enough charges to do it
        if (lightCharges == 0)
            return;

        // Reduce earth charges and update corresponding UI
        lightCharges--;
        UpdateChargesUI(lightTextCharges, lightCharges.ToString());

        // Create the light and start both Movement and Time coroutines
        GameObject _light = Instantiate(lightObject, transform.position, Quaternion.identity);
        StartCoroutine(MoveLight(_light, (Vector2)_light.transform.position + Vector2.up * 2));
        StartCoroutine(DelayLight(_light));
    }
    IEnumerator MoveLight(GameObject _light, Vector2 _target)
    {
        // Moves the light towards its target
        while(Vector2.Distance(_light.transform.position, _target) != 0)
        {
            // Hold if game is in pause
            while (WSB_PlayTestManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            _light.transform.position = Vector2.MoveTowards(_light.transform.position, _target, Time.deltaTime * 2);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator DelayLight(GameObject _ref)
    {
        // wait for lightDuration
        yield return new WaitForSeconds(lightDuration);

        // Start recharge light coroutine if not already started
        if (rechargeLight == null) 
            rechargeLight = StartCoroutine(RechargeLight());

        // Destroy this light when time is over
        Destroy(_ref);
    }

    IEnumerator RechargeLight()
    {
        // Wait for lightchargedelay
        yield return new WaitForSeconds(lightChargeDelay);

        // Increase light charges and update corresponding UI
        lightCharges++;
        UpdateChargesUI(lightTextCharges, lightCharges.ToString());

        // Checks if light charges are full, repeat this coroutine if not
        if (lightCharges < maxLightCharges)
            rechargeLight = StartCoroutine(RechargeLight());
        else
            rechargeLight = null;
    }
    #endregion

    #region Wind
    void Wind()
    {
        // Checks if Ban has enough charges to do it
        if (windCharges == 0)
            return;

        // Reduce wind charges and update corresponding UI
        windCharges--;
        UpdateChargesUI(windTextCharges, windCharges.ToString());

        blowCoroutine = StartCoroutine(Blow());
    }

    IEnumerator Blow()
    {
        WSB_Movable _physics;

        // Runs until coroutine is canceled
        while(true)
        {
            // Hold if game is in pause
            while (WSB_PlayTestManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            // Find all corresponding objects in range
            Collider2D[] _hits = Physics2D.OverlapCircleAll(transform.position, windRange, moveLayer);
            Collider2D _hit;

            // Loops through found objects
            for (int i = 0; i < _hits.Length; i++)
            {
                _hit = _hits[i];

                // Checks if player is standing on it, stop lifting if yes
                RaycastHit2D[] _checkPlayerOn = new RaycastHit2D[10];
                _hit.Cast(Vector2.up, new ContactFilter2D(), _checkPlayerOn);
                if (_checkPlayerOn.Any(_r => _r && _r.transform.GetComponent<WSB_Player>()))
                    continue;

                // Gets physic of hit object
                _physics = _hit.gameObject.GetComponent<WSB_Movable>();

                // if(raycast(pos, dir(pos, _hits.pos)) pas gêné, blow

                if (_physics)
                {
                    // Checks if object is a pot and try to break the seed in it
                    if (_hit.GetComponent<WSB_Pot>())
                        _hit.GetComponent<WSB_Pot>().BreakSeed();

                    // Add vertical force on the physic of the object
                    _physics.AddForce(Vector2.up * (windPower - (Vector2.Distance(transform.position, _hit.transform.position) / 2)));
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator RechargeWind()
    {
        // Wait for windchargedelay
        yield return new WaitForSeconds(windChargeDelay);

        // Increase wind charges and update corresponding UI
        windCharges++;
        UpdateChargesUI(windTextCharges, windCharges.ToString());


        // Checks if wind charges are full, repeat this coroutine if not
        if (windCharges < maxWindCharges)
            rechargeWind = StartCoroutine(RechargeWind());
        else
            rechargeWind = null;
    }

    #endregion

    void UpdateChargesUI(List<TMP_Text> _list, string _value)
    {
        // Sets text of each object in the list to the value given
        foreach (TMP_Text _txt in _list)
        {
            _txt.text = _value;
        }
    }
}
