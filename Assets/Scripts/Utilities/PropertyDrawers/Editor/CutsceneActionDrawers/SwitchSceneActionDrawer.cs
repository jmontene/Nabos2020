using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SwitchSceneCutsceneAction))]
public class SwitchSceneActionDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        SerializedObject obj = new SerializedObject(property.objectReferenceValue as SwitchSceneCutsceneAction);
        EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, 20), obj.FindProperty("sceneName"));
        EditorGUI.EndProperty();

    }
}