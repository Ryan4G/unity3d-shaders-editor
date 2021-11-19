using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(RuntimeColorChanger))]
[CanEditMultipleObjects]
public class RuntimeColorChangerEditor : Editor

{
    private Dictionary<string, Color> colorPresets;

    private SerializedProperty colorProperty;

    public void OnEnable()
    {
        colorPresets = new Dictionary<string, Color>();

        colorPresets["Red"] = Color.red;
        colorPresets["Blue"] = Color.blue;
        colorPresets["Yellow"] = Color.yellow;
        colorPresets["Green"] = Color.green;
        colorPresets["White"] = Color.white;

        colorProperty = serializedObject.FindProperty("color");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        using (var area = new EditorGUILayout.VerticalScope())
        {
            foreach (var preset in colorPresets)
            {
                var clicked = GUILayout.Button(preset.Key);

                if (clicked)
                {
                    colorProperty.colorValue = preset.Value;
                }
            }

            EditorGUILayout.PropertyField(colorProperty);
        }

        serializedObject.ApplyModifiedProperties();

        var msg = "You're doing a great job! Keep it up!";
        EditorGUILayout.HelpBox(msg, MessageType.Info);
    }
}
