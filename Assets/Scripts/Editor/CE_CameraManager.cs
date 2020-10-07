using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WSB_CameraManager))]
public class CE_CameraManager : Editor
{

    bool ceActive = true;

    SerializedProperty isOrtho;
    SerializedProperty camMoveSpeed;
    SerializedProperty camZoomSpeed;
    SerializedProperty minCamZoom;
    SerializedProperty maxCamZoom;

    private void OnEnable()
    {
        isOrtho = serializedObject.FindProperty("isOrtho");
        camMoveSpeed = serializedObject.FindProperty("camMoveSpeed");
        camZoomSpeed = serializedObject.FindProperty("camZoomSpeed");
        minCamZoom = serializedObject.FindProperty("minCamZoom");
        maxCamZoom = serializedObject.FindProperty("maxCamZoom");
    }



    public override void OnInspectorGUI()
    {
        WSB_CameraManager[] _foundManagers = FindObjectsOfType<WSB_CameraManager>();
        if(_foundManagers.Length > 1)
        {
            EditorGUILayout.HelpBox("There is more than one WSB_CameraManager in this scene.\nPlease delete unnecessary instances to have only one left.", MessageType.Error);
            EditorGUILayout.Space();
            for (int i = 0; i < _foundManagers.Length; i++)
            {
                EditorGUILayout.LabelField($"There is one instance on {_foundManagers[i].name}");
            }
            return;
        }

        ceActive = EditorGUILayout.ToggleLeft("Toggle custom editor", ceActive);

        if (!ceActive) base.OnInspectorGUI();
        else
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isOrtho);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Camera speeds :");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(camMoveSpeed);
            EditorGUILayout.PropertyField(camZoomSpeed);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Camera zoom properties :");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(minCamZoom);
            EditorGUILayout.PropertyField(maxCamZoom);
            EditorGUILayout.EndHorizontal();



            serializedObject.ApplyModifiedProperties();
        }
    }





}
