using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SetPlayerAnimationAction))]
public class SetPlayerAnimationDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        SetPlayerAnimationAction action = property.objectReferenceValue as SetPlayerAnimationAction;
        SerializedObject obj = new SerializedObject(action);
        
        EditorGUILayout.PropertyField(obj.FindProperty("parameterType"));
        EditorGUILayout.PropertyField(obj.FindProperty("parameterName"));
        switch (action.parameterType) {
            case AnimationParameterType.Bool:
                EditorGUILayout.PropertyField(obj.FindProperty("boolValue"));
                break;
            case AnimationParameterType.Int:
                EditorGUILayout.PropertyField(obj.FindProperty("intValue"));
                break;
            case AnimationParameterType.Float:
                EditorGUILayout.PropertyField(obj.FindProperty("floatValue"));
                break;
            default:
                break;
        }
        obj.ApplyModifiedProperties();
    }
}