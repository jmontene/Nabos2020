/// <summary>
/// Delegate for thw Player Movement event
/// </summary>
/// <param name="inputX">X input for movement</param>
/// <param name="inputY">Y input for movement</param>
public delegate void PlayerMovementEventDelegate(float inputX, float inputY);

/// <summary>
/// List of events that can be fired in the game (Might be separated in domains later)
/// </summary>
public static class EventHandler {
    /// <summary>
    /// Event that fires any time the player moves or stops moving
    /// </summary>
    public static event PlayerMovementEventDelegate PlayerMovementEvent;

    // Event callers

    /// <summary>
    /// Execute the player movement event
    /// </summary>
    /// <param name="inputX">X input for movement</param>
    /// <param name="inputY">Y input for movement</param>
    public static void CallMovementEvent(float inputX, float inputY) {
        if(PlayerMovementEvent != null) {
            PlayerMovementEvent(inputX, inputY);
        }
    }
}
