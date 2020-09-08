using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneDetails", menuName = "Nabos/Cutscenes/Cutscene")]
public class CutsceneDetails : ScriptableObject {
    public List<BaseCutsceneAction> actions;

    public CutsceneDetails() {
        actions = new List<BaseCutsceneAction>();
    }

    public void AddSwitchSceneAction() {
        SwitchSceneCutsceneAction action = ScriptableObject.CreateInstance<SwitchSceneCutsceneAction>();
        AssetDatabase.AddObjectToAsset(action, this);
        AssetDatabase.SaveAssets();
        actions.Add(action);
    }
}