using UnityEngine;

[System.Serializable]
public class BaseCutsceneAction : ScriptableObject, ICutsceneAction {
    public virtual string GetEditorName() {
        return "BaseCutsceneAction";
    }

    public virtual void Execute() { }
}