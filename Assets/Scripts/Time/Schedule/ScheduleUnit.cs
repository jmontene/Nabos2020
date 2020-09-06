using UnityEngine;

[System.Serializable]
public class ScheduleUnit {
    [SerializeField] public SceneName sceneName;
    [SerializeField] public string spawnName;

    public ScheduleUnit() {
        sceneName = SceneName.Scene000_None;
        spawnName = "";
    }
}
