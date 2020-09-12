using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ModalPopupAction))]
public class ModalPopupActionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        ModalPopupAction action = property.objectReferenceValue as ModalPopupAction;
        SerializedObject obj = new SerializedObject(action);
        EditorGUILayout.PropertyField(obj.FindProperty("popupText"));
        obj.ApplyModifiedProperties();
    }
}