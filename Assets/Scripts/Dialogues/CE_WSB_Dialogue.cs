using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WSB_Dialogue))]
public class CE_WSB_Dialogue : Editor
{
    WSB_Dialogue dialogue;

    bool isCustom = true;
    //bool showDialogues = true;

    private void OnEnable()
    {
        dialogue = (WSB_Dialogue)target;
    }

    public override void OnInspectorGUI()
    {
        isCustom = EditorGUILayout.ToggleLeft("Toggle custom editor ", isCustom);

        if(!isCustom)
        {
            base.OnInspectorGUI();
            return;
        }

        EditorGUILayout.Space();

        //showDialogues = EditorGUILayout.Toggle("Toggle dialogues ", showDialogues);
        //if (!showDialogues) return;

        SO_Dialogue _dialogue = null;

        if (GUILayout.Button("Add new dialogue")) dialogue.Dialogues.Add(null);

        EditorGUILayout.Space();

        for (int i = 0; i < dialogue.Dialogues.Count; i++)
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            dialogue.Dialogues[i] = (SO_Dialogue)EditorGUILayout.ObjectField("", dialogue.Dialogues[i], typeof(SO_Dialogue), true);

            if(GUILayout.Button("Remove this Dialoge"))
            {
                dialogue.Dialogues.RemoveAt(i);
                break;
            }
            EditorGUILayout.EndHorizontal();
            if (!dialogue.Dialogues[i]) continue;

            EditorGUILayout.Space();
            dialogue.Dialogues[i].Character = (Character)EditorGUILayout.EnumPopup("Character :", dialogue.Dialogues[i].Character);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            dialogue.Dialogues[i].Image = (Sprite)EditorGUILayout.ObjectField($"Image : {(dialogue.Dialogues[i].Image ? dialogue.Dialogues[i].Image.name : string.Empty)}", dialogue.Dialogues[i].Image, typeof(Sprite), false);

            dialogue.Dialogues[i].IsImageRight = EditorGUILayout.ToggleLeft("Is the image on the right side ? ", dialogue.Dialogues[i].IsImageRight);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            dialogue.Dialogues[i].ShowInCustomEditor = EditorGUILayout.Foldout(dialogue.Dialogues[i].ShowInCustomEditor, "Show texts", true);
            if (!dialogue.Dialogues[i].ShowInCustomEditor) continue;

            _dialogue = dialogue.Dialogues[i];

            //EditorGUILayout.LabelField(_dialogue.GetCharacter(), EditorStyles.boldLabel);
            for (int j = 0; j < _dialogue.Texts.Count; j++)
            {
                EditorGUILayout.Space();
                dialogue.Dialogues[i].Texts[j] = GUILayout.TextArea(_dialogue.GetText(j));
            }
            EditorGUILayout.Space();
        }
    }
}
