using UnityEngine;

[System.Serializable]
public class DailySchedule {
    [SerializeField] public ScheduleUnit morning;
    [SerializeField] public ScheduleUnit day;
    [SerializeField] public ScheduleUnit afternoon;
    [SerializeField] public ScheduleUnit evening;
    [SerializeField] public ScheduleUnit night;

    public void DebugPrint() {
        Debug.Log("Morning: " + morning.sceneName.ToString() + ", " + morning.spawnName);
        Debug.Log("Day: " + day.sceneName.ToString() + ", " + day.spawnName);
        Debug.Log("Afternoon: " + afternoon.sceneName.ToString() + ", " + afternoon.spawnName);
        Debug.Log("Evening: " + evening.sceneName.ToString() + ", " + evening.spawnName);
        Debug.Log("Night: " + night.sceneName.ToString() + ", " + night.spawnName);
    }

    public ScheduleUnit GetScheduleUnit(TimeSlot slot) {
        switch (slot) {
            case TimeSlot.Morning:
                return morning;
            case TimeSlot.Day:
                return day;
            case TimeSlot.Afternoon:
                return afternoon;
            case TimeSlot.Evening:
                return evening;
            case TimeSlot.Night:
                return night;
            default:
                return null;
        }
    }
}