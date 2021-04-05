using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Pot : LG_Movable
{
    [SerializeField] WSB_Carnivore carnivorePrefab = null;
    [SerializeField] WSB_Bridge bridgePrefab = null;
    [SerializeField] WSB_Trampoline trampolinePrefab = null;

    [SerializeField] Renderer rend = null;
    [SerializeField] ParticleSystem fx = null;

    [SerializeField] Vector2 spawnPos = Vector2.zero;

    public GameObject GrownSeed { get; private set; } = null;

    private void Awake()
    {
        // Populate rend var if not set properly
        if (!rend)
            rend = GetComponent<MeshRenderer>();
    }

    public override void Update()
    {
        base.Update();

        if(GrownSeed)
        {
            RaycastHit2D[] _hits = new RaycastHit2D[10];
            Physics2D.RaycastNonAlloc(transform.position, Vector2.up, _hits, 1);

            foreach (RaycastHit2D hit in _hits)
            {
                if (hit && hit.transform.gameObject != this.gameObject && (transform.parent && hit.transform.gameObject != transform.parent.gameObject) && !hit.transform.GetComponent<WSB_Player>() && hit.transform.gameObject != GrownSeed)
                {
                    BreakSeed();
                    return;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 2, .3f, .6f);
        Gizmos.DrawSphere((Vector2)transform.position + spawnPos, .1f);
    }

    private void OnDestroy()
    {
        // Calls a recharge on Lux if there was a seed in this pot
        if(GrownSeed && WSB_Lux.I)
            WSB_Lux.I.RechargeSeed(GrownSeed.tag);
    }


    public bool GrowSeed(string _seed)
    {
        // Break the seed and don't do anything else if there was already a seed in this pot
        if (GrownSeed)
        {
            BreakSeed();
            return false;
        }

        RaycastHit2D[] _hits = new RaycastHit2D[10];
        Physics2D.RaycastNonAlloc(transform.position, Vector2.up, _hits, 1);

        foreach (RaycastHit2D hit in _hits)
        {
            if (hit && hit.transform.gameObject != this.gameObject && (transform.parent && hit.transform.gameObject != transform.parent.gameObject))
            {
                return false;
            }
        }

        // Switch on the seed name to spawn corresponding prefab
        switch (_seed)
        {
            case "Carnivore":
                GrownSeed = Instantiate(carnivorePrefab, (Vector2)transform.position + spawnPos, Quaternion.identity).gameObject;
                break;
            case "Bridge":
                GrownSeed = Instantiate(bridgePrefab, (Vector2)transform.position + spawnPos, Quaternion.identity).gameObject;
                break;
            case "Trampoline":
                GrownSeed = Instantiate(trampolinePrefab, (Vector2)transform.position + spawnPos, Quaternion.identity).gameObject;
                break;
            default:
                return false;
        }

        // Set the seed as a child of this pot to be able to move the pot with the plant following it
        GrownSeed.transform.SetParent(this.transform);

        return true;
    }

    public void BreakSeed()
    {
        // If there is not seed, exit
        if (!GrownSeed)
            return;

        // Call the recharge of the seed and destroy the seed
        WSB_Lux.I.RechargeSeed(GrownSeed.tag);
        Destroy(GrownSeed.gameObject);
        GrownSeed = null;
    }
}
