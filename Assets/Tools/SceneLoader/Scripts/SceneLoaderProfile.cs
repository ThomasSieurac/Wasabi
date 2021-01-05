using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderProfile : ScriptableObject
{
    // Names of the folders
    public List<string> Folders = new List<string>();

    // Boolean for each folder to activate or not the foldout
    public List<bool> ActivatedFolders = new List<bool>();

    // List containing another List of each scene in every folders
    public List<ScenesData> ListedScenes = new List<ScenesData>();
}

[System.Serializable]
public class ScenesData
{
    public List<string> Content = new List<string>();
}