/// <summary>
/// Possible item types
/// </summary>
public enum ItemType {
    KeyItem
}

/// <summary>
/// Possible inventory locations
/// </summary>
public enum InventoryLocation {
    Player,
    Chest,
    Count
}

/// <summary>
/// Possible time slots
/// </summary>
public enum TimeSlot {
    Morning,
    Day,
    Afternoon,
    Evening,
    Night
}

public enum WeekDay {
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public enum Direction {
    Right,
    Left,
    Down,
    Up,
    None
}

public enum CutsceneActionType {
    SwitchScene,
    Dialogue,
    PassTime,
    SetPlayerAnimation,
    ModalPopup
}

public enum EventCode {
    EV001_Class
}

public enum PopupType {
    YesNo,
    Modal
}

public enum AnimationParameterType {
    Trigger,
    Bool,
    Int,
    Float
}

public enum PlayerAnimationParameterNames {
    Moving,
    Sitting,
    xDir,
    yDir,
}

public enum ScheduleCategory {
    Default,
    Class
} 

public enum SceneName {
    Scene000_None,
    Scene001_Test,
    Scene002_Test2,
    RM001_Dormitory
}