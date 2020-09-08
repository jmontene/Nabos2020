using UnityEngine;

[System.Serializable]
public class BaseCutsceneAction : ScriptableObject, ICutsceneAction {
    public virtual void Execute() { }
}