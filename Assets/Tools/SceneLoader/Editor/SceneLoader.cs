using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;


public class SceneLoader : EditorWindow
{
    string[] allScenes;
    Vector2 scrollPosition;

    static ScenesLoaderData data;

    //List<string> folders = new List<string>();
    //List<bool> activateFolder = new List<bool>();
    //List<List<string>> listedScenes = new List<List<string>>();

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

    private void OnGUI()
    {
        //folders.Clear();
        //activateFolder.Clear();
        //listedScenes.Clear();

        if (EditorApplication.isPlaying) 
            return;

        data = (ScenesLoaderData)EditorGUILayout.ObjectField(data, typeof(ScenesLoaderData));

        if (!data)
            return;

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        allScenes = AssetDatabase.FindAssets("t:scene");

        EditorGUILayout.Space();
        GUI.SetNextControlName("folder");
        editedFolder = EditorGUILayout.TextField(editedFolder);
        if(GUI.GetNameOfFocusedControl() == "folder")
        {
            if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return && !string.IsNullOrEmpty(editedFolder) && !data.Folders.Contains(editedFolder))
            {
                data.Folders.Add(editedFolder);
                data.ActivatedFolders.Add(false);
                data.ListedScenes.Add(new List<string>());
                EditorGUILayout.EndScrollView();
                return;
            }
        }
        GUI.SetNextControlName("");
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
        //EditorGUILayout.Space();

        for (int i = 0; i < data.Folders.Count; i++)
        {
            if (GUILayout.Button("Delete this folder"))
                if (EditorUtility.DisplayDialog("Deleting the folder " + data.Folders[i], "Are you sure ?\nThis is not reversible", "Confirm", "Cancel"))
                {
                    DeleteFolder(i);
                    EditorGUILayout.EndScrollView();
                    return;
                }
            data.ActivatedFolders[i] = EditorGUILayout.Foldout(data.ActivatedFolders[i], data.Folders[i], true);
            if (data.ActivatedFolders[i])
                ShowFolder(i);

            EditorGUILayout.Space();
            DrawLine(Color.gray);
        }

        EditorGUILayout.Space();
        Header("Unlisted scenes");
        //EditorGUILayout.Space();

        for (int i = 0; i < allScenes.Length; i++)
        {
            string _scenePath = AssetDatabase.GUIDToAssetPath(allScenes[i]);

            bool _alreadySet = false;

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

            ShowScene(_scenePath);
        }

        EditorGUILayout.EndScrollView();

        Repaint();
    }

    void DeleteFolder(int _i)
    {
        data.Folders.RemoveAt(_i);
        data.ListedScenes[_i].ForEach(s => AddToFolder("-99 " + s));
        data.ListedScenes.RemoveAt(_i);
        data.ActivatedFolders.RemoveAt(_i);
    }

    void ShowScene(string _path)
    {
        string[] _paths = _path.Split('\\');

        string[] _names = _paths[_paths.Length - 1].Split('/');

        _names[_names.Length - 1] = _names[_names.Length - 1].Replace(".unity", "");
        if (GUILayout.Button(_names[_names.Length - 1]))
        {
            if (Event.current.button == 1)
            {
                GenericMenu _menu = new GenericMenu();
                _menu.AddItem(new GUIContent("Unlist"), false, AddToFolder, "-99 " + _path);

                // Create a button to add for every created folders
                for (int j = 0; j < data.Folders.Count; j++)
                {
                    string _p = j.ToString() + " " + _path;
                    _menu.AddItem(new GUIContent(data.Folders[j]), false, AddToFolder, _p);
                }

                _menu.ShowAsContext();
            }
            else
            {
                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                EditorSceneManager.OpenScene(_path, OpenSceneMode.Single);
            }
        }

    }

    void ShowFolder(int _i)
    {
        for (int i = 0; i < data.ListedScenes[_i].Count; i++)
        {
            ShowScene(data.ListedScenes[_i][i]);
        }
    }

    void AddToFolder(object _p)
    {
        string[] _d = _p.ToString().Split(' ');
        for (int j = 0; j < data.Folders.Count; j++)
        {
            if (data.ListedScenes[j].Contains(_d[1]))
            {
                data.ListedScenes[j].Remove(_d[1]);
                break;
            }
        }
        int _i = int.Parse(_d[0]);
        if (_i == -99) 
            return;
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

[CreateAssetMenu(fileName = "ScenesLoaderData", menuName = "ScenesLoaderData/CreateScenesLoaderData", order = 1)]
public class ScenesLoaderData : ScriptableObject
{
    public List<string> Folders = new List<string>();
    public List<bool> ActivatedFolders = new List<bool>();
    public List<List<string>> ListedScenes = new List<List<string>>();
}