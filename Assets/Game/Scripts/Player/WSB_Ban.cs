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
    [SerializeField] float earthChargeDelay = 10;

    //Coroutine rechargeEarth = null;

    [SerializeField] LayerMask groundLayer = 0;
    [SerializeField] LayerMask earthLayer = 0;
    #endregion
    #region Light Spell
    [SerializeField] GameObject lightObject = null;

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

    [SerializeField] LayerMask windLayer = 0;

    #endregion

    #region RechargeSpells

    float earthTimer = 0;
    float shrinkTimer = 0;
    float lightTimer = 0;
    float windTimer = 0;

    int rechargeEarth = 0;
    int rechargeShrink = 0;
    int rechargeLight = 0;
    bool rechargeWind = false;

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
        if(rechargeEarth > 0)
        {
            // Increment the timer
            earthTimer += Time.deltaTime;

            // Update the filled image if there is no charges
            if(earthCharges == 0)
                spells.UpdateEmptyCharges(SpellType.Earth, earthTimer / earthChargeDelay);

            // If the timer has finished
            if(earthTimer >= earthChargeDelay)
            {
                rechargeEarth--;

                // Reset the timer
                earthTimer = 0;

                // Increment the charges and update the UI
                earthCharges++;
                if (earthCharges > maxEarthCharges)
                    earthCharges = maxEarthCharges;

                spells.UpdateChargesUI(SpellType.Earth, earthCharges.ToString());
                spells.UpdateEmptyCharges(SpellType.Earth, 1);

                // Check if charges are full and stop the recharge if yes
                if (earthCharges == maxEarthCharges)
                    rechargeEarth = 0;
            }
        }
        if(rechargeLight > 0)
        {
            lightTimer += Time.deltaTime;

            if (lightCharges == 0)
                spells.UpdateEmptyCharges(SpellType.Light, lightTimer / lightChargeDelay);

            if (lightTimer >= lightChargeDelay)
            {
                rechargeLight--;

                lightTimer = 0;

                lightCharges++;
                if (lightCharges > maxLightCharges)
                    lightCharges = maxLightCharges;

                spells.UpdateChargesUI(SpellType.Light, lightCharges.ToString());
                spells.UpdateEmptyCharges(SpellType.Light, 1);

                if (lightCharges == maxLightCharges)
                    rechargeLight = 0;
            }
        }
        if(rechargeShrink > 0)
        {
            shrinkTimer += Time.deltaTime;

            if (shrinkCharges == 0)
                spells.UpdateEmptyCharges(SpellType.Shrink, shrinkTimer / shrinkChargeDelay);

            if (shrinkTimer >= shrinkChargeDelay)
            {
                rechargeShrink--;

                shrinkTimer = 0;

                shrinkCharges++;
                if (shrinkCharges > maxShrinkCharges)
                    shrinkCharges = maxShrinkCharges;

                spells.UpdateChargesUI(SpellType.Shrink, shrinkCharges.ToString());
                spells.UpdateEmptyCharges(SpellType.Shrink, 1);

                if (shrinkCharges == maxShrinkCharges)
                    rechargeShrink = 0;
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
                if (windCharges > maxWindCharges)
                    windCharges = maxWindCharges;

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
            canMove = true;
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
        {
            rechargeShrink++;
            return;
        }

        // Reduce shrink charges and update corresponding UI
        shrinkCharges--;
        spells.UpdateChargesUI(SpellType.Shrink, shrinkCharges.ToString());
        if (shrinkCharges == 0)
            spells.UpdateEmptyCharges(SpellType.Shrink, shrinkTimer);
    }

    #endregion

    #region Earth
    void Earth()
    {
        // Checks if Ban has enough charges to do it
        if (earthCharges == 0)
            return;

        bool _spawn = false;
        // Loops for x amount from player left to player right below him to find ground
        for (int i = -earthSize; i < earthSize; i++)
        {
            RaycastHit2D[] _hits = Physics2D.RaycastAll(new Vector2(transform.position.x + (i / 10f), transform.position.y), Vector2.down, 1.5f, groundLayer);
            if(_hits.Length != 0)
            {
                // If ground found, Earth if spawned and exit this method
                _spawn = !RetrieveEarth();
                break;
            }
        }
        SpawnEarth(_spawn);
    }

    bool RetrieveEarth()
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y + .5f, earthLayer);
        if(!_hit)
            return false;
        else
        {
            if(_hit.transform.tag == "Earth")
            {
                Destroy(_hit.transform.gameObject);
                rechargeEarth++;
                return true;
            }
            return false;
        }
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
        }
        
        // If Earth didn't succesfully spawned
        else
        {
            // play bad FX
        }
    }

    #endregion

    #region Light

    [SerializeField] LayerMask lightLayer = 0;

    void Light()
    {
        // Search and retrieve the first active light found to disable it and recharge
        RaycastHit2D[] _hits = new RaycastHit2D[1];
        _hits = Physics2D.CircleCastAll(transform.position, 5, Vector2.right, 1, lightLayer);
        if(_hits.Length > 0 && _hits[0])
        {
            Destroy(_hits[0].transform.gameObject);
            rechargeLight++;
            return;
        }

        // Return is Ban is not grounded
        if (!isGrounded)
            return;

        // Checks if Ban has enough charges to do it
        if (lightCharges == 0)
            return;

        // Reduce earth charges and update corresponding UI
        lightCharges--;
        spells.UpdateChargesUI(SpellType.Light, lightCharges.ToString());
        if (lightCharges == 0)
            spells.UpdateEmptyCharges(SpellType.Light, lightTimer);

        // Create the light and start both Movement and Time coroutines
        GameObject _light = Instantiate(lightObject, new Vector3(transform.position.x,transform.position.y,-5), Quaternion.identity);
        StartCoroutine(MoveLight(_light, _light.transform.position + Vector3.up * 2));
    }




    IEnumerator MoveLight(GameObject _light, Vector3 _target)
    {
        // Moves the light towards its target
        while (_light && Vector3.Distance(_light.transform.position, _target) != 0)
        {
            // Hold if game is in pause
            while (WSB_GameManager.Paused)
            {
                yield return new WaitForSeconds(.2f);
            }

            _light.transform.position = Vector3.MoveTowards(_light.transform.position, _target, Time.deltaTime * 2);
            yield return new WaitForEndOfFrame();
        }
    }

    #endregion

    #region Wind
    void Wind()
    {
        // Checks if Ban has enough charges to do it
        if (windCharges == 0 || !isGrounded)
            return;

        // Reduce wind charges and update corresponding UI
        windCharges--;
        spells.UpdateChargesUI(SpellType.Wind, windCharges.ToString());
        if (windCharges == 0)
            spells.UpdateEmptyCharges(SpellType.Wind, windTimer);

        rechargeWind = false;
        blowCoroutine = StartCoroutine(Blow());
    }

    IEnumerator Blow()
    {
        WSB_Movable _physics;
        canMove = false;

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
                    if (_hit.GetComponent<WSB_Pot>() && _physics.CanMove)
                    {
                        _hit.GetComponent<WSB_Pot>().BreakSeed();
                    }

                    // Add vertical force on the physic of the object
                    _physics.AddForce(Vector2.up * (windPower/* - (Vector2.Distance(transform.position, _hit.transform.position) / 2)*/));
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }


    #endregion

}
