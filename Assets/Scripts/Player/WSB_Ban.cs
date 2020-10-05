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

    bool deb = false;
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

    private void OnDrawGizmos()
    {
        if (deb)
        {
            Gizmos.color = new Color(1, 1, 0, .25f);
            Gizmos.DrawSphere(transform.position, windRange);
        }
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.down * (transform.localScale.y + .5f));
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
        //deb = false;
        if (blowCoroutine != null) StopCoroutine(blowCoroutine);
    }

    void Shrink()
    {
        Debug.Log("Piti !");
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
            foreach (TMP_Text _txt in earthTextCharges)
            {
                _txt.text = earthCharges.ToString();
            }
            if(rechargeEarth == null) rechargeEarth = StartCoroutine(RechargeEarth());
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y + .5f, groundLayer);
            StartCoroutine(DelayEarth(Instantiate(earthZone, _hit.point, Quaternion.identity)));
        }
        else
        {
            // play bad FX
        }
        Debug.Log(_status);
    }

    IEnumerator DelayEarth(GameObject _ref)
    {
        yield return new WaitForSeconds(earthDuration);
        Destroy(_ref);
    }

    IEnumerator RechargeEarth()
    {
        yield return new WaitForSeconds(earthChargeDelay);
        earthCharges++;
        foreach (TMP_Text _txt in earthTextCharges)
        {
            _txt.text = earthCharges.ToString();
        }
        if (earthCharges < maxEarthCharges) rechargeEarth = StartCoroutine(RechargeEarth());
        else rechargeEarth = null;
    }
    #endregion

    void Light()
    {
        Debug.Log("Lumos !");
    }

    #region Wind
    void Wind()
    {
        //deb = true;
        windCharges--;
        foreach (TMP_Text _txt in windTextCharges)
        {
            _txt.text = windCharges.ToString();
        }
        blowCoroutine = StartCoroutine(Blow());
        if(rechargeWind == null) rechargeWind = StartCoroutine(RechargeWind());
    }

    IEnumerator RechargeWind()
    {
        yield return new WaitForSeconds(windChargeDelay);
        windCharges++;
        foreach (TMP_Text _txt in windTextCharges)
        {
            _txt.text = windCharges.ToString();
        }
        if (windCharges < maxWindCharges) rechargeWind = StartCoroutine(RechargeWind());
        else rechargeWind = null;
    }

    IEnumerator Blow()
    {
        while(true)
        {
            Collider2D[] _hits = Physics2D.OverlapCircleAll(transform.position, windRange, moveLayer);
            for (int i = 0; i < _hits.Length; i++)
            {
                if (_hits[i].gameObject.GetComponent<Rigidbody2D>() && _hits[i].gameObject.GetComponent<Rigidbody2D>().mass < windMaxMass) _hits[i].gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * windPower);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion
}
