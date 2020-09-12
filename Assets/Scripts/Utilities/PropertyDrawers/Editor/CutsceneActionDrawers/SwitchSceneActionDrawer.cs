using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SwitchSceneCutsceneAction))]
public class SwitchSceneActionDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedObject obj = new SerializedObject(property.objectReferenceValue as SwitchSceneCutsceneAction);
        EditorGUILayout.PropertyField(obj.FindProperty("sceneName"));
        EditorGUILayout.PropertyField(obj.FindProperty("spawnName"));
        EditorGUILayout.PropertyField(obj.FindProperty("endOnLoad"));
        obj.ApplyModifiedProperties();
    }
}