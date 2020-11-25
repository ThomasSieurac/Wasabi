using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSB_Pot : MonoBehaviour
{
    [SerializeField] WSB_Carnivore carnivorePrefab = null;
    [SerializeField] WSB_Bridge bridgePrefab = null;
    [SerializeField] WSB_Ladder ladderPrefab = null;
    [SerializeField] WSB_Trampoline trampolinePrefab = null;

    //[SerializeField] Vector2 spawnPos = Vector2.zero;

    public GameObject GrownSeed { get; private set; } = null;

    private void OnDestroy()
    {
        if(GrownSeed)
            WSB_Lux.I.RechargeSeed(GrownSeed.tag);
    }


    public void GrowSeed(string _seed)
    {
        //Debug.Log(_seed);
        if (GrownSeed) return;
        switch (_seed)
        {
            case "Carnivore":
                GrownSeed = Instantiate(carnivorePrefab, transform.position, Quaternion.identity).gameObject;
                break;
            case "Ladder":
                GrownSeed = Instantiate(ladderPrefab, transform.position, Quaternion.identity).gameObject;
                break;
            case "Bridge":
                GrownSeed = Instantiate(bridgePrefab, transform.position, Quaternion.identity).gameObject;
                break;
            case "Trampoline":
                GrownSeed = Instantiate(trampolinePrefab, transform.position, Quaternion.identity).gameObject;
                break;
            default:
                return;
        }
        GrownSeed.transform.SetParent(this.transform);
    }
}
