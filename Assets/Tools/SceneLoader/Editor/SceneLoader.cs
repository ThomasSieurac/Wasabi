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
        if (EditorApplication.isPlaying) return;
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        allScenes = AssetDatabase.FindAssets("t:scene");

        for (int i = 0; i < allScenes.Length; i++)
        {
            string _scenePath = AssetDatabase.GUIDToAssetPath(allScenes[i]);
            string[] _paths = _scenePath.Split('\\');

            string[] _names = _paths[_paths.Length - 1].Split('/');
            for (int j = 0; j < _names.Length; j++)
            {
                _names[j] = _names[j].Replace(".unity", "");
            }

            if (GUILayout.Button(_names[_names.Length - 1]))
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                EditorSceneManager.OpenScene(_scenePath, OpenSceneMode.Single);
            }
        }
        EditorGUILayout.EndScrollView();
        Repaint();
    }
}
