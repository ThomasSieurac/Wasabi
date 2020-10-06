using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System.Reflection;

[CustomEditor(typeof(WSB_Button))]
public class CE_Button : Editor
{
    SerializedProperty activateEvent;
    SerializedProperty duration;
    GameObject owner;

    bool customEditor = true;
    bool showEvents = false;

    private void OnEnable()
    {
        WSB_Button _b = (WSB_Button)serializedObject.targetObject;
        owner = _b.gameObject;
        activateEvent = serializedObject.FindProperty("onActivate");
        duration = serializedObject.FindProperty("duration");
    }


    public override void OnInspectorGUI()
    {
        //customEditor = GUILayout.Toggle(customEditor, "Toggle Custom Editor");
        //GUILayout.Space(25);
        if (customEditor)
        {
            serializedObject.Update();
            EditorGUILayout.LabelField("The delay the button will take to get back in initial position :");
            EditorGUILayout.Space();
            
            EditorGUILayout.PropertyField(duration);

            EditorGUILayout.Space();
            showEvents = EditorGUILayout.Foldout(showEvents, "Show Events", true);
            if(showEvents) EditorGUILayout.PropertyField(activateEvent);
            serializedObject.ApplyModifiedProperties();
        }
        else base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
        var path = activateEvent.propertyPath.Replace(".Array.data[", "[");
        object obj = activateEvent.serializedObject.targetObject;
        var elements = path.Split('.');
        foreach (var element in elements)
        {
            if (element.Contains("["))
            {
                var elementName = element.Substring(0, element.IndexOf("["));
                var index = System.Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
                obj = GetValue_Imp(obj, elementName, index);
            }
            else
            {
                obj = GetValue_Imp(obj, element);
            }
        }
        if (obj != null)
        {
            UnityEvent _activate = (UnityEvent)obj;
            int _length = _activate.GetPersistentEventCount();
            if (_length > 0)
            {
                for (int i = 0; i < _length; i++)
                {
                    Object _object = _activate.GetPersistentTarget(i);
                    if (_object)
                    {
                        GameObject _target = (GameObject)_object;
                        if (_target)
                        {
                            Handles.color = Color.green;
                            Handles.DrawLine(_target.transform.position, owner.transform.position);

                        }
                    }
                }
            }
        }
    }


    private static object GetValue_Imp(object source, string name)
    {
        if (source == null)
            return null;
        var type = source.GetType();

        while (type != null)
        {
            var f = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (f != null)
                return f.GetValue(source);

            var p = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p != null)
                return p.GetValue(source, null);

            type = type.BaseType;
        }
        return null;
    }
    private static object GetValue_Imp(object source, string name, int index)
    {
        var enumerable = GetValue_Imp(source, name) as System.Collections.IEnumerable;
        if (enumerable == null) return null;
        var enm = enumerable.GetEnumerator();
        //while (index-- >= 0)
        //    enm.MoveNext();
        //return enm.Current;

        for (int i = 0; i <= index; i++)
        {
            if (!enm.MoveNext()) return null;
        }
        return enm.Current;
    }

}
