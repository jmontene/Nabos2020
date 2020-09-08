using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneDetails", menuName = "Nabos/Cutscenes/Cutscene")]
public class CutsceneDetails : ScriptableObject {
    public List<BaseCutsceneAction> actions;

    public CutsceneDetails() {
        actions = new List<BaseCutsceneAction>();
    }

    public void AddAction<T>(string name) where T : BaseCutsceneAction {
        T action = ScriptableObject.CreateInstance<T>();
        action.name = name;
        AssetDatabase.AddObjectToAsset(action, this);
        AssetDatabase.SaveAssets();
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath((T)action));
        actions.Add(action);
    }

    public void RemoveAction(int index) {
        BaseCutsceneAction action = actions[index];
        actions.Remove(action);
        AssetDatabase.RemoveObjectFromAsset(action);
        AssetDatabase.SaveAssets();
    }
}