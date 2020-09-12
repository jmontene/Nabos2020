using System.Collections.Generic;

public class ScheduleUnitData {
    public Dictionary<ScheduleCategory, ScheduleUnit> units;

    public ScheduleUnitData() {
        units = new Dictionary<ScheduleCategory, ScheduleUnit>();
    }
}