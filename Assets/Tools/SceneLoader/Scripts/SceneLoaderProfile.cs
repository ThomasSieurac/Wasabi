using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderProfile : ScriptableObject
{
    public List<string> Folders = new List<string>();
    public List<bool> ActivatedFolders = new List<bool>();
    public List<List<string>> ListedScenes = new List<List<string>>();
}
