using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Pot : MonoBehaviour
{
    [SerializeField] WSB_Carnivore carnivorePrefab = null;
    [SerializeField] WSB_Bridge bridgePrefab = null;
    [SerializeField] WSB_Ladder ladderPrefab = null;
    [SerializeField] WSB_Trampoline trampolinePrefab = null;
    [SerializeField] bool isCursed = false;
    public bool IsCursed { get { return isCursed; } }
    [SerializeField] Material cursedMat = null;
    [SerializeField] Material uncursedMat = null;
    [SerializeField] Renderer rend = null;

    [SerializeField] Vector2 spawnPos = Vector2.zero;

    public GameObject GrownSeed { get; private set; } = null;

    private void Awake()
    {
        // Populate rend var if not set properly
        if (!rend)
            rend = GetComponent<MeshRenderer>();

        // Initiate the curse of the pot
        SetCurse(isCursed);
    }
    private void Update()
    {
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
        if(GrownSeed)
            WSB_Lux.I.RechargeSeed(GrownSeed.tag);
    }


    public bool GrowSeed(string _seed)
    {
        // Don't do anything if the pot is cursed
        if (isCursed)
            return false;

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
            case "Ladder":
                GrownSeed = Instantiate(ladderPrefab, (Vector2)transform.position + spawnPos, Quaternion.identity).gameObject;
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

    public void SetCurse(bool _state)
    {
        // If the pot is cursed break any seed planted and change the material to cursed
        if(_state)
        {
            BreakSeed();
            if(rend)
                rend.material = cursedMat;
            isCursed = true;
        }
        // If the pot isn't cursed change the material to uncursed
        else
        {
            rend.material = uncursedMat;
            isCursed = false;
        }
    }
}
