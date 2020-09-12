using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DailySchedule {
    [SerializeField] public List<ScheduleUnit> morning;
    [SerializeField] public List<ScheduleUnit> day;
    [SerializeField] public List<ScheduleUnit> afternoon;
    [SerializeField] public List<ScheduleUnit> evening;
    [SerializeField] public List<ScheduleUnit> night;
}