using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WSB_Dialogue))]
public class CE_WSB_Dialogue : Editor
{
    WSB_Dialogue dialogue;

    bool ceActive = true;
    //bool showDialogues = true;

    SerializedProperty dialogues;




    private void OnEnable()
    {
        dialogues = serializedObject.FindProperty("Dialogues");
        //dialogue = (WSB_Dialogue)target;
    }

    public override void OnInspectorGUI()
    {
        ceActive = EditorGUILayout.ToggleLeft("Toggle custom editor ", ceActive);

        if(!ceActive)
        {
            base.OnInspectorGUI();
            return;
        }
        serializedObject.Update();

        EditorGUILayout.Space();

        if (GUILayout.Button("Add new dialogue", EditorStyles.miniButtonMid))
        {
            dialogues.InsertArrayElementAtIndex(dialogues.arraySize);
            if (dialogues.GetArrayElementAtIndex(dialogues.arraySize - 1).objectReferenceValue != null)
                dialogues.DeleteArrayElementAtIndex(dialogues.arraySize - 1);

        }

        EditorGUILayout.Space();

        for (int i = 0; i < dialogues.arraySize; i++)
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            
            EditorGUILayout.Space();

            SerializedProperty _dialogue = dialogues.GetArrayElementAtIndex(i);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Delete this dialogue", GUILayout.Width(150)))
            {
                if(_dialogue.objectReferenceValue != null)
                    dialogues.DeleteArrayElementAtIndex(i);
                dialogues.DeleteArrayElementAtIndex(i);
                break;
            }

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_dialogue, GUIContent.none, GUILayout.MaxWidth(200));

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();


            if (_dialogue.objectReferenceValue == null)
                continue;

            SerializedObject _dialogueObject = new SerializedObject(_dialogue.objectReferenceValue);

            _dialogueObject.Update();

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(_dialogueObject.FindProperty("IsImageRight"));
            EditorGUILayout.PropertyField(_dialogueObject.FindProperty("Image"), GUIContent.none, GUILayout.MaxWidth(200));

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_dialogueObject.FindProperty("Character"), GUIContent.none, GUILayout.Width(100));
            EditorGUILayout.Space();

            SerializedProperty _showText = _dialogueObject.FindProperty("ShowTexts");

            EditorGUILayout.PropertyField(_showText);

            if(_showText.boolValue)
            {
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(_dialogueObject.FindProperty("Texts"), true);
                EditorGUILayout.Space();
            }


            _dialogueObject.ApplyModifiedProperties();
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);



        serializedObject.ApplyModifiedProperties();

        //showDialogues = EditorGUILayout.Toggle("Toggle dialogues ", showDialogues);
        //if (!showDialogues) return;

        //SO_Dialogue _dialogue = null;

        //if (GUILayout.Button("Add new dialogue")) dialogue.Dialogues.Add(null);

        //EditorGUILayout.Space();

        //for (int i = 0; i < dialogue.Dialogues.Count; i++)
        //{
        //    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        //    //EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1));

        //    EditorGUILayout.Space();
        //    EditorGUILayout.BeginHorizontal();
        //    dialogue.Dialogues[i] = (SO_Dialogue)EditorGUILayout.ObjectField("", dialogue.Dialogues[i], typeof(SO_Dialogue), true);

        //    if(GUILayout.Button("Remove this Dialoge"))
        //    {
        //        dialogue.Dialogues.RemoveAt(i);
        //        break;
        //    }
        //    EditorGUILayout.EndHorizontal();
        //    if (!dialogue.Dialogues[i]) continue;

        //    EditorGUILayout.Space();
        //    dialogue.Dialogues[i].Character = (Character)EditorGUILayout.EnumPopup("Character :", dialogue.Dialogues[i].Character);

        //    EditorGUILayout.BeginHorizontal();
        //    EditorGUILayout.Space();
        //    dialogue.Dialogues[i].Image = (Sprite)EditorGUILayout.ObjectField($"Image : {(dialogue.Dialogues[i].Image ? dialogue.Dialogues[i].Image.name : string.Empty)}", dialogue.Dialogues[i].Image, typeof(Sprite), false);

        //    dialogue.Dialogues[i].IsImageRight = EditorGUILayout.ToggleLeft("Is the image on the right side ? ", dialogue.Dialogues[i].IsImageRight);
        //    EditorGUILayout.EndHorizontal();

        //    EditorGUILayout.Space();
        //    dialogue.Dialogues[i].ShowInCustomEditor = EditorGUILayout.Foldout(dialogue.Dialogues[i].ShowInCustomEditor, "Show texts", true);
        //    if (!dialogue.Dialogues[i].ShowInCustomEditor) continue;

        //    if (GUILayout.Button("Create new text")) dialogue.Dialogues[i].Texts.Add("");
        //    EditorGUILayout.Space();

        //    _dialogue = dialogue.Dialogues[i];


        //    for (int j = 0; j < _dialogue.Texts.Count; j++)
        //    {
        //        EditorGUILayout.BeginHorizontal();
        //        if (GUILayout.Button("Delete this text", GUILayout.Width(100)))
        //        {
        //            dialogue.Dialogues[i].Texts.RemoveAt(j);
        //            break;
        //        }
        //        dialogue.Dialogues[i].Texts[j] = GUILayout.TextArea(_dialogue.GetText(j));
        //        EditorGUILayout.EndHorizontal();
        //    }
        //    EditorGUILayout.Space();
        //}
    }
}
