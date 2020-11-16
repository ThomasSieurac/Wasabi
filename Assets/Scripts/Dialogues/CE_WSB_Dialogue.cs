using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WSB_Dialogue))]
public class CE_WSB_Dialogue : Editor
{

    bool ceActive = true;

    SerializedProperty dialogues;
    SerializedObject dialogueObject;
    GUIStyle deleteStyle;

    Color defaultColor;
    TextEditor lastTextSelected = null;


    private void OnEnable()
    {
        dialogues = serializedObject.FindProperty("Dialogues");
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

        deleteStyle = new GUIStyle(EditorStyles.miniButton);
        deleteStyle.fontStyle = FontStyle.Bold;
        deleteStyle.normal.textColor = Color.white;

        defaultColor = GUI.backgroundColor;

        EditorGUILayout.Space();

        if (GUILayout.Button("Add new dialogue", GUILayout.MaxWidth(200)))
        {
            dialogues.InsertArrayElementAtIndex(dialogues.arraySize);
            if (dialogues.GetArrayElementAtIndex(dialogues.arraySize - 1).objectReferenceValue != null)
                dialogues.DeleteArrayElementAtIndex(dialogues.arraySize - 1);
        }

        EditorGUILayout.Space();

        ShowDialogues();

        EditorGUILayout.Space();

        DrawLine(new Color(.7f, .7f, .7f, 1));

        serializedObject.ApplyModifiedProperties();

    }

    void ShowDialogues()
    {
        for (int i = 0; i < dialogues.arraySize; i++)
        {
            DrawLine(new Color(.7f, .7f, .7f, 1));

            EditorGUILayout.Space();

            SerializedProperty _dialogue = dialogues.GetArrayElementAtIndex(i);

            EditorGUILayout.BeginHorizontal();

            GUI.backgroundColor = new Color(2, 0, 0, 1);

            if (GUILayout.Button("Delete this dialogue", deleteStyle, GUILayout.Width(150)))
            {
                if (_dialogue.objectReferenceValue != null)
                    dialogues.DeleteArrayElementAtIndex(i);
                dialogues.DeleteArrayElementAtIndex(i);
                break;
            }

            GUI.backgroundColor = defaultColor;

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_dialogue, GUIContent.none, GUILayout.MaxWidth(200));

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();


            if (_dialogue.objectReferenceValue == null)
                continue;

            dialogueObject = new SerializedObject(_dialogue.objectReferenceValue);

            dialogueObject.Update();

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(dialogueObject.FindProperty("IsImageRight"));
            EditorGUILayout.PropertyField(dialogueObject.FindProperty("Image"), GUIContent.none, GUILayout.MaxWidth(200));

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(dialogueObject.FindProperty("Character"), GUIContent.none, GUILayout.Width(100));
            EditorGUILayout.Space();

            SerializedProperty _showText = dialogueObject.FindProperty("ShowTexts");

            _showText.boolValue = EditorGUILayout.Foldout(_showText.boolValue, "Show texts", true);

            if (_showText.boolValue)
            {
                EditorGUILayout.Space();

                SerializedProperty _text = dialogueObject.FindProperty("Texts");

                if (GUILayout.Button("Add new text"))
                {
                    _text.InsertArrayElementAtIndex(_text.arraySize);
                    _text.GetArrayElementAtIndex(_text.arraySize - 1).stringValue = "";
                }

                EditorGUILayout.Space();

                ShowText(_text);

            }

            EditorGUILayout.Space();

            dialogueObject.ApplyModifiedProperties();

        }

    }

    void ShowText(SerializedProperty _text)
    {
        for (int j = 0; j < _text.arraySize; j++)
        {
            Rect _rect = EditorGUILayout.GetControlRect();

            EditorGUI.DrawRect(new Rect(_rect.x + _rect.width / 4, _rect.y, _rect.width / 2, 2), Color.gray);

            EditorGUILayout.Space();

            MarkdownText(_text, j);

            string _s = _text.GetArrayElementAtIndex(j).stringValue;

            /*
             * 
             * choper le string
             * 
             * afficher le string sans les markdown
             * 
             * enregistrer le string avec les markdown
             * 
             */

            _text.GetArrayElementAtIndex(j).stringValue = GUILayout.TextArea(_s);

            EditorGUILayout.Space();

            GUI.backgroundColor = new Color(2, 0, 0, 1);

            if (GUILayout.Button("Delete this text", deleteStyle, GUILayout.Width(150)))
            {
                _text.DeleteArrayElementAtIndex(j);
                break;
            }

            GUI.backgroundColor = defaultColor;

            EditorGUILayout.Space();
        }
    }

    void MarkdownText(SerializedProperty _text, int _index)
    {
        EditorGUILayout.BeginHorizontal();

        lastTextSelected = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

        if (GUILayout.Button("Bold"))
        {
            if (!string.IsNullOrEmpty(lastTextSelected.text) && lastTextSelected.hasSelection)
            {
                lastTextSelected.ReplaceSelection($"<b>{lastTextSelected.SelectedText}</b>");
                _text.GetArrayElementAtIndex(_index).stringValue = lastTextSelected.text;
            }
        }

        if (GUILayout.Button("Underline"))
        {
            if (!string.IsNullOrEmpty(lastTextSelected.text) && lastTextSelected.hasSelection)
            {
                lastTextSelected.ReplaceSelection($"<u>{lastTextSelected.SelectedText}</u>");
                _text.GetArrayElementAtIndex(_index).stringValue = lastTextSelected.text;
            }
        }

        if (GUILayout.Button("Italic"))
        {
            if (!string.IsNullOrEmpty(lastTextSelected.text) && lastTextSelected.hasSelection)
            {
                lastTextSelected.ReplaceSelection($"<i>{lastTextSelected.SelectedText}</i>");
                _text.GetArrayElementAtIndex(_index).stringValue = lastTextSelected.text;
            }
        }

        if (GUILayout.Button("Color"))
        {
            ColorPopup.Init(this, ref _text, _index);
        }


        EditorGUILayout.EndHorizontal();
    }

    public void ApplyColorMarkDown(Color _c, ref SerializedProperty _text, int _index)
    {
        if (!string.IsNullOrEmpty(lastTextSelected.text) && lastTextSelected.hasSelection)
        {
            serializedObject.Update();
            dialogueObject.Update();

            lastTextSelected.ReplaceSelection($"<color=#{ColorUtility.ToHtmlStringRGBA(_c)}>{lastTextSelected.SelectedText}</color>");

            _text.GetArrayElementAtIndex(_index).stringValue = lastTextSelected.text;

            Debug.Log(_text.GetArrayElementAtIndex(_index).stringValue);

            dialogueObject.ApplyModifiedProperties();
            serializedObject.ApplyModifiedProperties();
        }
    }

    void DrawLine(Color _c) => EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), _c);
}

public class ColorPopup : EditorWindow
{
    Color textColor = Color.white;
    static SerializedProperty property = null;
    static int index = 0;
    static CE_WSB_Dialogue ce = null;

    static ColorPopup popup = null;

    public static void Init(CE_WSB_Dialogue _ce, ref SerializedProperty _text, int _index)
    {
        if (popup) popup.Close();
        property = _text;
        index = _index;
        ce = _ce;
        popup = ScriptableObject.CreateInstance<ColorPopup>();
        Vector2 _pos = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
        popup.position = new Rect(_pos.x, _pos.y, 100, 75);
        popup.ShowPopup();
    }

    private void OnGUI()
    {
        textColor = EditorGUILayout.ColorField(textColor);
        GUILayout.Space(5);
        if(GUILayout.Button("Apply"))
        {
            ce.ApplyColorMarkDown(textColor,ref property, index);
            popup.Close();
        }
        if (GUILayout.Button("Close"))
            popup.Close();
    }
}
