using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WSB_Dialogue))]
public class CE_WSB_Dialogue : Editor
{

    bool ceActive = true;

    SerializedProperty dialogues;




    private void OnEnable()
    {
        dialogues = serializedObject.FindProperty("Dialogues");
        //dialogue = (WSB_Dialogue)target;
    }

    public override void OnInspectorGUI()
    {
        ceActive = EditorGUILayout.ToggleLeft("Toggle custom editor ", ceActive);

        if (!ceActive)
        {
            base.OnInspectorGUI();
            return;
        }
        serializedObject.Update();

        GUIStyle _deleteStyle = new GUIStyle(EditorStyles.miniButton);
        _deleteStyle.fontStyle = FontStyle.Bold;
        _deleteStyle.normal.textColor = Color.white;

        Color _defaultColor = GUI.backgroundColor;

        EditorGUILayout.Space();

        if (GUILayout.Button("Add new dialogue", GUILayout.MaxWidth(200)))
        {
            dialogues.InsertArrayElementAtIndex(dialogues.arraySize);
            if (dialogues.GetArrayElementAtIndex(dialogues.arraySize - 1).objectReferenceValue != null)
                dialogues.DeleteArrayElementAtIndex(dialogues.arraySize - 1);
        }

        EditorGUILayout.Space();

        for (int i = 0; i < dialogues.arraySize; i++)
        {
            DrawLine(new Color(.7f, .7f, .7f, 1));

            EditorGUILayout.Space();

            SerializedProperty _dialogue = dialogues.GetArrayElementAtIndex(i);

            EditorGUILayout.BeginHorizontal();

            GUI.backgroundColor = new Color(2, 0, 0, 1);

            if (GUILayout.Button("Delete this dialogue", _deleteStyle, GUILayout.Width(150)))
            {
                if (_dialogue.objectReferenceValue != null)
                    dialogues.DeleteArrayElementAtIndex(i);
                dialogues.DeleteArrayElementAtIndex(i);
                break;
            }

            GUI.backgroundColor = _defaultColor;

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

            _showText.boolValue = EditorGUILayout.Foldout(_showText.boolValue, "Show texts", true);

            if (_showText.boolValue)
            {
                EditorGUILayout.Space();

                SerializedProperty _text = _dialogueObject.FindProperty("Texts");

                if (GUILayout.Button("Add new text"))
                {
                    _text.InsertArrayElementAtIndex(_text.arraySize);
                    _text.GetArrayElementAtIndex(_text.arraySize - 1).stringValue = "";
                }

                EditorGUILayout.Space();

                for (int j = 0; j < _text.arraySize; j++)
                {
                    Rect _rect = EditorGUILayout.GetControlRect();

                    EditorGUI.DrawRect(new Rect(_rect.x + _rect.width/4, _rect.y, _rect.width / 2, 2), Color.gray);

                    EditorGUILayout.Space();

                    _text.GetArrayElementAtIndex(j).stringValue = GUILayout.TextArea(_text.GetArrayElementAtIndex(j).stringValue);

                    EditorGUILayout.Space();

                    GUI.backgroundColor = new Color(2,0,0,1);

                    if (GUILayout.Button("Delete this text", _deleteStyle, GUILayout.Width(150)))
                    {
                        _text.DeleteArrayElementAtIndex(j);
                        break;
                    }

                    GUI.backgroundColor = _defaultColor;

                    EditorGUILayout.Space();
                }

            }
            
            EditorGUILayout.Space();

            _dialogueObject.ApplyModifiedProperties();

        }

        EditorGUILayout.Space();

        DrawLine(new Color(.7f, .7f, .7f, 1));

        serializedObject.ApplyModifiedProperties();

    }

    void DrawLine(Color _c) => EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), _c);
}
