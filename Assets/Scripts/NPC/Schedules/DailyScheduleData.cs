using System.Collections.Generic;

public class DailyScheduleData {
    public Dictionary<TimeSlot, ScheduleUnitData> data;

    public DailyScheduleData() {
        data = new Dictionary<TimeSlot, ScheduleUnitData>();
    }

    public void SetTimeSlot(TimeSlot slot, List<ScheduleUnit> units) {
        if (!data.ContainsKey(slot)) {
            data.Add(slot, new ScheduleUnitData());
        }

        foreach(ScheduleUnit unit in units) {
            data[slot].units[unit.scheduleCategory] = unit;
        }
    }
}