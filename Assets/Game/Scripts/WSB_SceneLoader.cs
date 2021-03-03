using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WSB_SceneLoader : MonoBehaviour
{
    [SerializeField] List<string> allScenesInOrder = new List<string>();
    [SerializeField] bool doLoad = true;

    void Start()
    {
        if (!doLoad)
            return;

        for (int i = 0; i < allScenesInOrder.Count; i++)
        {
            SceneManager.LoadScene(allScenesInOrder[i], LoadSceneMode.Additive);
        }
    }

}
