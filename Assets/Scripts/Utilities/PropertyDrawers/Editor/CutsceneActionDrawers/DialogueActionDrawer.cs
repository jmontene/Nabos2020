using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DialogueCutsceneAction))]
public class DialogueActionDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        DialogueCutsceneAction action = property.objectReferenceValue as DialogueCutsceneAction;
        SerializedObject obj = new SerializedObject(action);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(obj.FindProperty("dialogueCode"));
        EditorGUILayout.LabelField(GetDialogueName(action.dialogueCode));
        EditorGUILayout.EndHorizontal();

        obj.ApplyModifiedProperties();
    }

    private string GetDialogueName(int code) {
        SO_DialoguesList dialogueList = AssetDatabase.LoadAssetAtPath<SO_DialoguesList>("Assets/Databases/so_DialogueList.asset");
        List<DialogueDetails> list = dialogueList.dialogues;
        DialogueDetails detail = list.Find(x => x.dialogueCode == code);

        return detail != null ? detail.descriptiveName : "DIALOGUE_NOT_FOUND";
    }
}