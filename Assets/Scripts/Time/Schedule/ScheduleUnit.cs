using UnityEngine;

[System.Serializable]
public class ScheduleUnit {
    [SerializeField] public string descriptiveName;
    [SerializeField] public ScheduleCategory scheduleCategory;
    [SerializeField] public SceneName sceneName;
    [SerializeField] public string spawnName;

    public ScheduleUnit() {
        descriptiveName = "";
        sceneName = SceneName.Scene000_None;
        spawnName = "";
    }
}
