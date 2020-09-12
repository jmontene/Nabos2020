using System.Collections.Generic;

public class NPCScheduleData {
    public Dictionary<WeekDay, DailyScheduleData> dailyData;

    public NPCScheduleData() {
        dailyData = new Dictionary<WeekDay, DailyScheduleData>();
    }

    public void SetDaily(WeekDay day, DailySchedule daily) {
        if (!dailyData.ContainsKey(day)) {
            dailyData.Add(day, new DailyScheduleData());
        }

        dailyData[day].SetTimeSlot(TimeSlot.Morning, daily.morning);
        dailyData[day].SetTimeSlot(TimeSlot.Day, daily.day);
        dailyData[day].SetTimeSlot(TimeSlot.Afternoon, daily.afternoon);
        dailyData[day].SetTimeSlot(TimeSlot.Evening, daily.evening);
        dailyData[day].SetTimeSlot(TimeSlot.Night, daily.night);
    }

    public ScheduleUnit GetScheduleUnit(WeekDay day, TimeSlot slot, ScheduleCategory category = ScheduleCategory.Default) {
        if (dailyData.TryGetValue(day, out DailyScheduleData daily)) {
            if (daily.data.TryGetValue(slot, out ScheduleUnitData unitData)) {
                return unitData.units.TryGetValue(category, out ScheduleUnit res) ? res : null;
            }
        }

        return null;
    }
}