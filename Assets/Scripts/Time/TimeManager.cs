using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonMonoBehaviour<TimeManager> {
    [HideInInspector] public TimeSlot currentTimeslot;
    [HideInInspector] public WeekDay currentWeekDay;

    private int num_slots;
    private int num_days;

    protected override void Awake() {
        base.Awake();
        currentTimeslot = TimeSlot.Morning;
        currentWeekDay = WeekDay.Monday;
        num_slots = Enum.GetValues(typeof(TimeSlot)).Length;
        num_days = Enum.GetValues(typeof(WeekDay)).Length;

        DebugPrint();
    }

    public void NextSlot() {
        currentTimeslot = (TimeSlot)(((int)(currentTimeslot + 1)) % num_slots);
        if (currentTimeslot == TimeSlot.Morning) {
            NextDay();
        }
    }

    private void NextDay() {
        currentWeekDay = (WeekDay)(((int)(currentWeekDay + 1)) % num_days);
    }

    // Debug Methods

    public void DebugPrint() {
        Debug.Log($"Current Day: {currentWeekDay}, Current Time: {currentTimeslot}");
    }
}
