using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Ban : WSB_Player
{

    #region Spell Charges
    [SerializeField] int earthCharges = 10;
    [SerializeField] int shrinkCharges = 10;
    [SerializeField] int windCharges = 10;
    [SerializeField] int lightCharges = 10;
    #endregion
    #region Earth Spell

    #endregion
    #region Light Spell

    #endregion
    #region Shrink Spell

    #endregion
    #region Wind Spell
    [SerializeField] float range = 5;
    [SerializeField] float power = 2;
    [SerializeField] float maxMass = 20;

    Coroutine blowCoroutine = null;

    [SerializeField] LayerMask moveLayer = 0;

    bool deb = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    private void OnDrawGizmos()
    {
        if (deb)
        {
            Gizmos.color = new Color(1, 1, 0, .25f);
            Gizmos.DrawSphere(transform.position, range);
        }
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
        deb = false;
        if (blowCoroutine != null) StopCoroutine(blowCoroutine);
    }

    void Shrink()
    {
        Debug.Log("Piti !");
    }

    void Earth()
    {
        Debug.Log("Caillou !");
    }

    void Light()
    {
        Debug.Log("Lumos !");
    }

    void Wind()
    {
        deb = true;
        blowCoroutine = StartCoroutine(Blow());
    }

    IEnumerator Blow()
    {
        while(true)
        {
            Collider2D[] _hits = Physics2D.OverlapCircleAll(transform.position, range, moveLayer);
            for (int i = 0; i < _hits.Length; i++)
            {
                if (_hits[i].gameObject.GetComponent<Rigidbody2D>()) _hits[i].gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * power);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
