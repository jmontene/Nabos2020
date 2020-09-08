using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DialogueCutsceneAction))]
public class DialogueActionDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        SerializedObject obj = new SerializedObject(property.objectReferenceValue as DialogueCutsceneAction);
        EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, 20), obj.FindProperty("dialogueCode"));
        obj.ApplyModifiedProperties();
    }
}