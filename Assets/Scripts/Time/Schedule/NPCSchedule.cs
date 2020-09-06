using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCSchedule", menuName = "Nabos/NPC/NPCSchedule")]
public class NPCSchedule : ScriptableObject {
    public DailySchedule monday;
    public DailySchedule tuesday;
    public DailySchedule wednesday;
    public DailySchedule thursday;
    public DailySchedule friday;
    public DailySchedule saturday;
    public DailySchedule sunday;

    public void DebugPrintInfo() {
        Debug.Log("*************************NPC Schedule Info************************");
        monday.DebugPrint();
        tuesday.DebugPrint();
        wednesday.DebugPrint();
        thursday.DebugPrint();
        friday.DebugPrint();
        saturday.DebugPrint();
        sunday.DebugPrint();
        Debug.Log("******************************************************************");
    }

    public ScheduleUnit GetScheduleUnit(WeekDay day, TimeSlot slot) {
        switch (day) {
            case WeekDay.Monday:
                return monday.GetScheduleUnit(slot);
            case WeekDay.Tuesday:
                return tuesday.GetScheduleUnit(slot);
            case WeekDay.Wednesday:
                return wednesday.GetScheduleUnit(slot);
            case WeekDay.Thursday:
                return thursday.GetScheduleUnit(slot);
            case WeekDay.Friday:
                return friday.GetScheduleUnit(slot);
            case WeekDay.Saturday:
                return saturday.GetScheduleUnit(slot);
            case WeekDay.Sunday:
                return sunday.GetScheduleUnit(slot);
            default:
                return null;
        }
    }
}