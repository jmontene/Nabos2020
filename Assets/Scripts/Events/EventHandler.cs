using System;
using System.Collections.Generic;

/// <summary>
/// Delegate for the Player Movement event
/// </summary>
/// <param name="inputX">X input for movement</param>
/// <param name="inputY">Y input for movement</param>
public delegate void PlayerMovementEventDelegate(float inputX, float inputY);

/// <summary>
/// Delegate for the Inventory change event
/// </summary>
/// <param name="location">Location of the inventory</param>
/// <param name="inventory">Inventory contents</param>
public delegate void InventoryChangeEventDelegate(InventoryLocation location, List<InventoryItem> inventory);

/// <summary>
/// List of events that can be fired in the game (Might be separated in domains later)
/// </summary>
public static class EventHandler {
    /// <summary>
    /// Event that fires any time the player moves or stops moving
    /// </summary>
    public static event PlayerMovementEventDelegate PlayerMovementEvent;

    /// <summary>
    /// Event that fires any time an inventory changes
    /// </summary>
    public static event InventoryChangeEventDelegate InventoryChangeEvent;

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

    public static void CallInventoryChangeEvent(InventoryLocation location, List<InventoryItem> inventory) {
        if (InventoryChangeEvent != null) {
            InventoryChangeEvent(location, inventory);
        }
    }
}
