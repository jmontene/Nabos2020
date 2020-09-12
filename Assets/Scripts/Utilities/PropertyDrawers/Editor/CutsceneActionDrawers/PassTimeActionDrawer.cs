using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PassTimeCutsceneAction))]
public class PassTimeActionDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUILayout.LabelField("(No Parameters)");
    }
}