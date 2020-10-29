using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Pot : MonoBehaviour
{
    [SerializeField] WSB_Carnivore carnivorePrefab = null;
    [SerializeField] WSB_Bridge bridgePrefab = null;
    [SerializeField] WSB_Ladder ladderPrefab = null;
    [SerializeField] WSB_Trampoline trampolinePrefab = null;

    [SerializeField] Vector2 spawnPos = Vector2.zero;

    public GameObject GrownSeed { get; private set; } = null;

    private void OnDestroy()
    {
        //lux.RechargeSeed(grownSeed.tag);
    }


    public void GrowSeed(string _seed)
    {
        Debug.Log(_seed);
        if (GrownSeed) return;
        switch (_seed)
        {
            case "Carnivore":
                GrownSeed = Instantiate(carnivorePrefab, spawnPos, Quaternion.identity).gameObject;
                break;
            case "Ladder":
                GrownSeed = Instantiate(ladderPrefab, spawnPos, Quaternion.identity).gameObject;
                break;
            case "Bridge":
                GrownSeed = Instantiate(bridgePrefab, spawnPos, Quaternion.identity).gameObject;
                break;
            case "Trampoline":
                GrownSeed = Instantiate(trampolinePrefab, spawnPos, Quaternion.identity).gameObject;
                break;
            default:
                return;
        }
        GrownSeed.transform.SetParent(this.transform);
    }
}
