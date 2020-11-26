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
        if (!rend)
            rend = GetComponent<MeshRenderer>();
        SetCurse(isCursed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 2, .3f, .6f);
        Gizmos.DrawSphere((Vector2)transform.position + spawnPos, .1f);
    }

    private void OnDestroy()
    {
        if(GrownSeed)
            WSB_Lux.I.RechargeSeed(GrownSeed.tag);
    }


    public bool GrowSeed(string _seed)
    {
        if (isCursed)
            return false;
        if (GrownSeed)
        {
            BreakSeed();
            return false;
        }
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
        GrownSeed.transform.SetParent(this.transform);
        return true;
    }

    public void BreakSeed()
    {
        if (!GrownSeed)
            return;
        WSB_Lux.I.RechargeSeed(GrownSeed.tag);
        Destroy(GrownSeed.gameObject);
        GrownSeed = null;
    }

    public void SetCurse(bool _state)
    {
        if(_state)
        {
            BreakSeed();
            rend.material = cursedMat;
            isCursed = true;
        }
        else
        {
            rend.material = uncursedMat;
            isCursed = false;
        }
    }
}
