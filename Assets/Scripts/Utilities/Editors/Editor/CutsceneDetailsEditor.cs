using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CutsceneDetails))]
public class CutsceneDetailsEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Add Scene Switch")) {
            (serializedObject.targetObject as CutsceneDetails).AddSwitchSceneAction();
        }
    }
}