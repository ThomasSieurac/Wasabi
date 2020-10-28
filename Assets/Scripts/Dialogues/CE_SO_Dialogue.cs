using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SO_Dialogue))]
public class CE_SO_Dialogue : Editor
{
    SO_Dialogue dialogue;

    bool isCustom = true;
    bool showTexts = true;

    private void OnEnable()
    {
        //dialogue = (SO_Dialogue)target;
    }
    private void OnDisable()
    {
        //dialogue = null;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //if(!dialogue)
        //{
        //    EditorGUILayout.HelpBox("Missing WSB_Dialogue script.", MessageType.Error);
        //    return;
        //}
        //isCustom = GUILayout.Toggle(isCustom, "Toggle custom editor");
        //EditorGUILayout.Space();
        //if (!isCustom)
        //{
        //    base.OnInspectorGUI();
        //    return;
        //}
        //dialogue.Image = (Sprite)EditorGUILayout.ObjectField($"Image : {(dialogue.Image ? dialogue.Image.name : string.Empty)}", dialogue.Image, typeof(Sprite), false);
        //EditorGUILayout.Space();
        //dialogue.IsImageRight = EditorGUILayout.ToggleLeft("Is the image on the right side ?", dialogue.IsImageRight);
        //EditorGUILayout.Space();
        //dialogue.Character = (Character)EditorGUILayout.EnumPopup("Character :", dialogue.Character);
        //EditorGUILayout.Space();
        //EditorGUILayout.Space();
        //if (showTexts = EditorGUILayout.Foldout(showTexts, "Toggle texts", true))
        //{
        //    GUI.contentColor = new Color(0,.9f,0,1);
        //    if (GUILayout.Button("Create new dialogue")) dialogue.Texts.Add(string.Empty);
        //    EditorGUILayout.Space();
        //    EditorGUILayout.Space();
        //    for (int i = 0; i < dialogue.Texts.Count; i++)
        //    {
        //        EditorGUILayout.Space();
        //        EditorGUILayout.BeginHorizontal();
        //        GUI.contentColor = new Color(.9f,0,0,1);
        //        if (GUILayout.Button("Delete this dialogue"))
        //        {
        //            dialogue.Texts.RemoveAt(i);
        //            break;
        //        }
        //        GUI.contentColor = Color.white;
        //        dialogue.Texts[i] = GUILayout.TextArea(dialogue.Texts[i]);
        //        EditorGUILayout.EndHorizontal();
        //    }
        //}
    }



}
