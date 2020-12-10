using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class SceneLoader : EditorWindow
{
    string[] allScenes;
    Vector2 scrollPosition;

    SceneLoaderProfile data;


    string editedFolder = "";

    [MenuItem("Tools/Scene Loader")]
    public static void Init()
    {
        EditorWindow _u = GetWindow(typeof(SceneLoader), false, "Scene Loader");
        _u.autoRepaintOnSceneChange = true;
    }

    private void OnEnable()
    {
        scrollPosition = new Vector2(0, 0);
    }

    int CreateProfileRecursively(int _i)
    {
        if (AssetDatabase.FindAssets("NewSceneLoaderProfile" + _i).Length > 0)
            return CreateProfileRecursively(_i + 1);
        else
            return _i;
    }

    void CheckForData()
    {
        data = (SceneLoaderProfile)EditorGUILayout.ObjectField(data, typeof(SceneLoaderProfile), false);

        if (!data)
        {
            editedFolder = "";
            if (GUILayout.Button("Create new Profile"))
            {
                // Get the paths
                MonoScript _ms = MonoScript.FromScriptableObject(this);
                string _editorPath = AssetDatabase.GetAssetPath(_ms);
                string _mainFolder = _editorPath.Replace("/Editor/SceneLoader.cs", "");
                string _profilesPath = _mainFolder + "/Profiles";
                _editorPath = _mainFolder + "/Editor";

                // Create the Profiles folder if not present
                if (!AssetDatabase.IsValidFolder(_profilesPath))
                {
                    AssetDatabase.CreateFolder(_mainFolder, "Profiles");
                }

                // Get a new name for the new Profile so it doesn't replace the previous one
                int _i = CreateProfileRecursively(1);

                // Edit the current path to the correct Profiles one
                _editorPath = _editorPath.Replace("Editor", $"Profiles/NewSceneLoaderProfile{_i}.asset");

                // Create the data
                data = (SceneLoaderProfile)CreateInstance(typeof(SceneLoaderProfile));
                AssetDatabase.CreateAsset(data, _editorPath);
                AssetDatabase.SaveAssets();
            }
            return;
        }
    }

    private void OnGUI()
    {
        if (EditorApplication.isPlaying) 
            return;

        CheckForData();

        if (!data)
            return;

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        // Get all the scenes
        allScenes = AssetDatabase.FindAssets("t:scene");

        EditorGUILayout.Space();

        // Makes the TextField and allow for both Enter input
        GUI.SetNextControlName("folder");
        editedFolder = EditorGUILayout.TextField(editedFolder);

        if(GUI.GetNameOfFocusedControl() == "folder")
        {
            if (Event.current.type == EventType.KeyUp && (Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter) && !string.IsNullOrEmpty(editedFolder) && !data.Folders.Contains(editedFolder))
            {
                data.Folders.Add(editedFolder);
                data.ActivatedFolders.Add(false);
                data.ListedScenes.Add(new List<string>());
                EditorGUILayout.EndScrollView();
                return;
            }
        }
        GUI.SetNextControlName("");


        // Create the button to create a new folder
        EditorGUILayout.Space();
        if(GUILayout.Button("Create folder " + editedFolder) && !string.IsNullOrEmpty(editedFolder) && !data.Folders.Contains(editedFolder))
        {
            data.Folders.Add(editedFolder);
            data.ActivatedFolders.Add(false);
            data.ListedScenes.Add(new List<string>());
            EditorGUILayout.EndScrollView();
            return;
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        Header("Folders");

        // Loop through all the folders
        for (int i = 0; i < data.Folders.Count; i++)
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();

            // Button to delete the current folder
            if (GUILayout.Button("Delete this folder"))
            {
                if (EditorUtility.DisplayDialog("Deleting the folder " + data.Folders[i], "Are you sure ?\nThis is not reversible", "Confirm", "Cancel"))
                {
                    DeleteFolder(i);
                    EditorGUILayout.EndScrollView();
                    return;
                }
            }

            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            // Foldout for the current folder
            data.ActivatedFolders[i] = EditorGUILayout.Foldout(data.ActivatedFolders[i], data.Folders[i], true);
            if (data.ActivatedFolders[i])
                ShowFolder(i);

            EditorGUILayout.Space();
            DrawLine(Color.gray);
        }

        EditorGUILayout.Space();
        Header("Unlisted scenes");

        // Loop through all the scenes
        for (int i = 0; i < allScenes.Length; i++)
        {
            // Get the path to that scene
            string _scenePath = AssetDatabase.GUIDToAssetPath(allScenes[i]);

            bool _alreadySet = false;

            // Loop though each folder to find the current scene if already located in a folder
            for (int j = 0; j < data.Folders.Count; j++)
            {
                if (data.ListedScenes[j].Contains(_scenePath))
                {
                    _alreadySet = true;
                    break;
                }
            }
            if (_alreadySet)
                continue;

            // If not already in a folder, sets it in Unlisted
            ShowScene(_scenePath);
        }

        EditorGUILayout.EndScrollView();

        Repaint();
    }

    void DeleteFolder(int _i)
    {
        // Delete the folder
        data.Folders.RemoveAt(_i);

        // Look if there was any scene in the folder and clear the list if so
        if(data.ListedScenes.Count > 0 && data.ListedScenes[_i].Count > 0)
        {
            for (int j = 0; j < data.Folders.Count; j++)
            {
                if (data.ListedScenes[j].Contains(data.ListedScenes[_i][0]))
                {
                    data.ListedScenes[j].Clear();
                    break;
                }
            }
        }

        // Delete the listed scene and activatedFolder lists at the index of the deleted folder
        data.ListedScenes.RemoveAt(_i);
        data.ActivatedFolders.RemoveAt(_i);
    }

    void ShowScene(string _path)
    {
        // Get only the name of the scene
        string[] _paths = _path.Split('\\');
        string[] _names = _paths[_paths.Length - 1].Split('/');
        _names[_names.Length - 1] = _names[_names.Length - 1].Replace(".unity", "");

        // Button with only the name of the scene
        if (GUILayout.Button(_names[_names.Length - 1]))
        {
            // Right click creates a menu to select the folder where to set the scene
            if (Event.current.button == 1)
            {
                GenericMenu _menu = new GenericMenu();
                _menu.AddItem(new GUIContent("Unlist"), false, AddToFolder, "-99¤" + _path);

                // Create a button to add for every created folders
                for (int j = 0; j < data.Folders.Count; j++)
                {
                    string _p = j.ToString() + "¤" + _path;
                    _menu.AddItem(new GUIContent(data.Folders[j]), false, AddToFolder, _p);
                }

                _menu.ShowAsContext();
            }
            // Left click to save current scene if needed and load selected scene
            else
            {
                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                EditorSceneManager.OpenScene(_path, OpenSceneMode.Single);
            }
        }

    }

    void ShowFolder(int _i)
    {
        // Loop through the scenes of the folder
        for (int i = 0; i < data.ListedScenes[_i].Count; i++)
        {
            ShowScene(data.ListedScenes[_i][i]);
        }
    }

    void AddToFolder(object _p)
    {
        // Retrieve the data containing the index and the path of this scene
        string[] _d = _p.ToString().Split('¤');

        // Loops through all the folders to find if the path exists somewhere and remove it
        for (int j = 0; j < data.Folders.Count; j++)
        {
            if (data.ListedScenes[j].Contains(_d[1]))
            {
                data.ListedScenes[j].Remove(_d[1]);
                break;
            }
        }

        int _i = int.Parse(_d[0]);

        // Return if the scene has to be Unlisted
        if (_i == -99) 
            return;

        // Add the scene to the correct folder
        data.ListedScenes[_i].Add(_d[1]);
    }


    void DrawLine(Color _c) => EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), _c);

    void Header(string _title)
    {
        GUIStyle bold = new GUIStyle(EditorStyles.label);
        bold.fontStyle = FontStyle.Bold;
        bold.fontSize = 12;
        bold.alignment = TextAnchor.MiddleCenter;

        GUIContent _content = new GUIContent(_title);

        Vector2 _size = bold.CalcSize(_content);

        EditorGUILayout.BeginHorizontal();

        Rect _rect = EditorGUILayout.GetControlRect();

        float _width = _rect.width / 2 - (_size.x / 2 + 10);

        EditorGUI.DrawRect(new Rect(_rect.x, _rect.y, _width, 2), Color.gray);
        EditorGUI.LabelField(new Rect(_rect.x, _rect.y - 10, _rect.width, _rect.height), _title, bold);
        EditorGUI.DrawRect(new Rect(_rect.xMax - _width, _rect.y, _width, 2), Color.gray);


        EditorGUILayout.EndHorizontal();
    }
}
