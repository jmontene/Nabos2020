using System.Collections.Generic;

public class NPCData {
    public int npcCode;
    public NPCScheduleData currentSchedule;

    public void SetSchedule(NPCSchedule schedule) {
        if (currentSchedule == null) {
            currentSchedule = new NPCScheduleData();
        }
        currentSchedule.SetDaily(WeekDay.Monday, schedule.monday);
        currentSchedule.SetDaily(WeekDay.Tuesday, schedule.tuesday);
        currentSchedule.SetDaily(WeekDay.Wednesday, schedule.wednesday);
        currentSchedule.SetDaily(WeekDay.Thursday, schedule.thursday);
        currentSchedule.SetDaily(WeekDay.Friday, schedule.friday);
        currentSchedule.SetDaily(WeekDay.Saturday, schedule.saturday);
        currentSchedule.SetDaily(WeekDay.Sunday, schedule.sunday);
    }
}