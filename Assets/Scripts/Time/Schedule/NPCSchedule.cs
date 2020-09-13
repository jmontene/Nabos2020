using System;
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
}