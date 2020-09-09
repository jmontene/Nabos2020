using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CutsceneDetails))]
public class CutsceneDetailsEditor : Editor {
    private List<bool> collapse;
    private CutsceneActionType typeSelected;

    protected void OnEnable() {
        collapse = new List<bool>();
        typeSelected = CutsceneActionType.SwitchScene;
        CutsceneDetails obj = serializedObject.targetObject as CutsceneDetails;
        for (int i = 0; i < obj.actions.Count; ++i) {
            collapse.Add(false);
        }
    }

    public override void OnInspectorGUI() {
        CutsceneDetails obj = serializedObject.targetObject as CutsceneDetails;
        for (int i = 0; i < obj.actions.Count; ++i) {
            SerializedProperty property = serializedObject.FindProperty($"actions.Array.data[{i}]");
            if (property != null) {
                BaseCutsceneAction act = property.objectReferenceValue as BaseCutsceneAction;
                if (i >= collapse.Count) {
                    collapse.Add(false);
                }
                EditorGUILayout.BeginHorizontal();
                collapse[i] = EditorGUILayout.Foldout(collapse[i], act.GetEditorName());
                if (GUILayout.Button("X")) {
                    collapse.RemoveAt(i);
                    RemoveAction(obj, i);
                    EditorGUILayout.EndHorizontal();
                    continue;
                }
                EditorGUILayout.EndHorizontal();
                if (collapse[i]) {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(property);
                    EditorGUI.indentLevel--;
                }
            }
        }

        EditorGUILayout.LabelField("Add Action");

        EditorGUI.indentLevel++;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Action Type");
        typeSelected = (CutsceneActionType) EditorGUILayout.EnumPopup(typeSelected);
        EditorGUILayout.EndHorizontal();

        switch(typeSelected){
            case CutsceneActionType.SwitchScene:
                AddActionButton<SwitchSceneCutsceneAction>(obj, "Add Scene Switch", "SwitchScene");
                break;
            case CutsceneActionType.Dialogue:
                AddActionButton<DialogueCutsceneAction>(obj, "Add Dialogue Action", "StartDialogue");
                break;
            case CutsceneActionType.PassTime:
                AddActionButton<PassTimeCutsceneAction>(obj, "Add Pass Time Action", "Pass Time");
                break;
        }
        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
        EditorUtility.SetDirty(obj);
    }

    private void AddActionButton<T>(CutsceneDetails obj, string label, string assetName) where T : BaseCutsceneAction {
        if (GUILayout.Button(label)) {
            obj.AddAction<T>(assetName);
        }
    }

    private void RemoveAction(CutsceneDetails obj, int index) {
        obj.RemoveAction(index);
    }
}