using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SwitchSceneCutsceneAction))]
public class SwitchSceneActionDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.LabelField(new Rect(position.x, position.y, position.width, 20), "Scene Name");
        EditorGUI.PropertyField(new Rect(position.x, position.y + 20, position.width, 20), property.FindPropertyRelative("sceneName"));
    }
}