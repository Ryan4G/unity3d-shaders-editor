using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TextureCounter : EditorWindow
{
    private string stringValue;
    private string delayValue;

    private int intValue;
    private float floatValue;
    private Vector2 vector2DValue;
    private Vector3 vector3DValue;

    private float minFloatValue;
    private float maxFloatValue;

    private enum DamageType
    {
        Fire,
        Frost,
        Electric,
        Shadow
    }

    private DamageType damageType;

    private Vector2 scrollPosition;

    [MenuItem("Window/Texture Counter")]
    public static void init()
    {
        var window = EditorWindow.GetWindow<TextureCounter>("Texture Counter");

        DontDestroyOnLoad(window);
    }

    private void OnGUI()
    {
        //GUI.Label(new Rect(50, 50, 100, 20), "This is a label");

        using (var verticalArea = new EditorGUILayout.ScrollViewScope(this.scrollPosition))
        {
            this.scrollPosition = verticalArea.scrollPosition;

            GUILayout.Label("These");
            GUILayout.Label("Labels");
            GUILayout.Label("Will be shown");
            GUILayout.Label("On top of each other");

            var button = GUILayout.Button("Click me!");

            if (button)
            {
                Debug.Log("This custom window's button was clicked!");
            }

            GUILayout.Label("TextArea");
            this.stringValue = EditorGUILayout.TextArea(this.stringValue, GUILayout.Height(80));

            GUILayout.Label("Delay InputField");
            this.delayValue = EditorGUILayout.DelayedTextField(this.delayValue);

            GUILayout.Label("Repeat Delay LabelField");
            EditorGUILayout.LabelField(this.delayValue);

            GUILayout.Space(20);
            GUILayout.Label("Special Fields");
            this.intValue = EditorGUILayout.IntField("Int", this.intValue);
            this.floatValue = EditorGUILayout.FloatField("Float", this.floatValue);
            this.vector2DValue = EditorGUILayout.Vector2Field("Vector 2D", this.vector2DValue);
            this.vector3DValue = EditorGUILayout.Vector3Field("Vector 3D", this.vector3DValue);

            GUILayout.Label("Slider");

            var minLimit = 0;
            var maxLimit = 10;
            EditorGUILayout.MinMaxSlider(ref minFloatValue, ref maxFloatValue, minLimit, maxLimit);

            // ComboBox
            GUILayout.Label("ComboBox");

            this.damageType = (DamageType)EditorGUILayout.EnumPopup(damageType);

            var paths = AssetDatabase.FindAssets("t:texture");

            var count = paths.Length;

            EditorGUILayout.LabelField("Texture Count", count.ToString());
        }
    }
}
