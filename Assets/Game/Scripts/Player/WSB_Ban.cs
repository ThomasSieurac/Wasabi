using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class WSB_Ban : WSB_Player
{
    public static WSB_Ban I { get; private set; }

    [SerializeField] WSB_Spells spells = null;

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
    [SerializeField] GameObject earthZone = null;

    [SerializeField] int earthSize = 5;
    [SerializeField] float earthDuration = 20;
    [SerializeField] float earthChargeDelay = 10;

    //Coroutine rechargeEarth = null;

    [SerializeField] LayerMask groundLayer = 0;
    #endregion
    #region Light Spell
    [SerializeField] GameObject lightObject = null;

    [SerializeField] float lightDuration = 10;
    [SerializeField] float lightChargeDelay = 10;

    //Coroutine rechargeLight = null;
    #endregion
    #region Shrink Spell
    [SerializeField] float shrinkChargeDelay = 10;

    //Coroutine rechargeShrink = null;
    #endregion
    #region Wind Spell
    [SerializeField] float windRange = 5;
    [SerializeField] float windPower = 2;
    [SerializeField] float windChargeDelay = 10;

    Coroutine blowCoroutine = null;
    //Coroutine rechargeWind = null;

    [SerializeField] LayerMask moveLayer = 0;
    [SerializeField] LayerMask windLayer = 0;

    #endregion

    #region RechargeSpells

    float earthTimer = 0;
    float windTimer = 0;
    float shrinkTimer = 0;
    float lightTimer = 0;

    bool rechargeEarth = false;
    bool rechargeWind = false;
    bool rechargeShrink = false;
    bool rechargeLight = false;

    #endregion

    // Sets instance of this object
    protected override void Awake()
    {
        base.Awake();
        I = this;
    }

    // Setup variables and events
    private void Start()
    {
        WSB_GameManager.OnUpdate += MyUpdate;
        WSB_GameManager.OnPause += StopSpell;
        windCharges = maxWindCharges;
        earthCharges = maxEarthCharges;
        lightCharges = maxLightCharges;
        shrinkCharges = maxShrinkCharges;
        spells.UpdateChargesUI(SpellType.Earth, earthCharges.ToString());
        spells.UpdateChargesUI(SpellType.Light, lightCharges.ToString());
        spells.UpdateChargesUI(SpellType.Shrink, shrinkCharges.ToString());
        spells.UpdateChargesUI(SpellType.Wind, windCharges.ToString());
    }
    protected override void Update()
    {
        // Has to be here and empty to override Unity update and use MyUpdate below
    }

    // Update called on bound event
    void MyUpdate()
    {
        base.Update();

        // Recharge the spells
        if(rechargeEarth)
        {
            // Increment the timer
            earthTimer += Time.deltaTime;

            // Update the filled image if there is no charges
            if(earthCharges == 0)
                spells.UpdateEmptyCharges(SpellType.Earth, earthTimer / earthChargeDelay);

            // If the timer has finished
            if(earthTimer >= earthChargeDelay)
            {
                // Reset the timer
                earthTimer = 0;

                // Increment the charges and update the UI
                earthCharges++;
                spells.UpdateChargesUI(SpellType.Earth, earthCharges.ToString());
                spells.UpdateEmptyCharges(SpellType.Earth, 1);

                // Check if charges are full and stop the recharge if yes
                if (earthCharges == maxEarthCharges)
                    rechargeEarth = false;
            }
        }
        if(rechargeLight)
        {
            lightTimer += Time.deltaTime;

            if (lightCharges == 0)
                spells.UpdateEmptyCharges(SpellType.Light, lightTimer / lightChargeDelay);

            if (lightTimer >= lightChargeDelay)
            {
                lightTimer = 0;

                lightCharges++;
                spells.UpdateChargesUI(SpellType.Light, lightCharges.ToString());
                spells.UpdateEmptyCharges(SpellType.Light, 1);

                if (lightCharges == maxLightCharges)
                    rechargeLight = false;
            }
        }
        if(rechargeShrink)
        {
            shrinkTimer += Time.deltaTime;

            if (shrinkCharges == 0)
                spells.UpdateEmptyCharges(SpellType.Shrink, shrinkTimer / shrinkChargeDelay);

            if (shrinkTimer >= shrinkChargeDelay)
            {
                shrinkTimer = 0;

                shrinkCharges++;
                spells.UpdateChargesUI(SpellType.Shrink, shrinkCharges.ToString());
                spells.UpdateEmptyCharges(SpellType.Shrink, 1);

                if (shrinkCharges == maxLightCharges)
                    rechargeShrink = false;
            }
        }
        if(rechargeWind)
        {
            windTimer += Time.deltaTime;

            if (windCharges == 0)
                spells.UpdateEmptyCharges(SpellType.Wind, windTimer / windChargeDelay);

            if (windTimer >= windChargeDelay)
            {
                windTimer = 0;

                windCharges++;
                spells.UpdateChargesUI(SpellType.Wind, windCharges.ToString());
                spells.UpdateEmptyCharges(SpellType.Wind, 1);

                if (windCharges== maxWindCharges)
                    rechargeWind = false;
            }
        }
    }



    public override void UseSpell(string _s)
    {
        base.UseSpell(_s);
        if (WSB_GameManager.Paused)
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
            rechargeWind = true;
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
        spells.UpdateChargesUI(SpellType.Shrink, shrinkCharges.ToString());
        if (shrinkCharges == 0)
            spells.UpdateEmptyCharges(SpellType.Shrink, shrinkTimer);

        rechargeShrink = true;
        // Start coroutine to recharge the spell if not existing
        //if (rechargeShrink != null)
        //    StopCoroutine(rechargeShrink);
        //rechargeShrink = StartCoroutine(RechargeShrink());
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
            spells.UpdateChargesUI(SpellType.Earth, earthCharges.ToString());
            if(earthCharges == 0)
                spells.UpdateEmptyCharges(SpellType.Earth, earthTimer);


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

        rechargeEarth = true;
        //// Start recharge earth coroutine if not already started
        //if (rechargeEarth == null)
        //    rechargeEarth = StartCoroutine(RechargeEarth());

        // Destroy this Earth when time is over
        Destroy(_ref);
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
        spells.UpdateChargesUI(SpellType.Light, lightCharges.ToString());
        if (lightCharges == 0)
            spells.UpdateEmptyCharges(SpellType.Light, lightTimer);

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
            while (WSB_GameManager.Paused)
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

        rechargeLight = true;
        //// Start recharge light coroutine if not already started
        //if (rechargeLight == null) 
        //    rechargeLight = StartCoroutine(RechargeLight());

        // Destroy this light when time is over
        Destroy(_ref);
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
        spells.UpdateChargesUI(SpellType.Wind, windCharges.ToString());
        if (windCharges == 0)
            spells.UpdateEmptyCharges(SpellType.Wind, windTimer);

        blowCoroutine = StartCoroutine(Blow());
    }

    IEnumerator Blow()
    {
        WSB_Movable _physics;

        // Runs until coroutine is canceled
        while(true)
        {
            // Hold if game is in pause
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            // Find all corresponding objects in range
            Collider2D[] _hits = Physics2D.OverlapCircleAll(transform.position, windRange, windLayer);
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
                    _physics.AddForce(Vector2.up * (windPower/* - (Vector2.Distance(transform.position, _hit.transform.position) / 2)*/));
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }


    #endregion

}
