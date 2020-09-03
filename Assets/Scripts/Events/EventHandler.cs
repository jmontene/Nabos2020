﻿using System;
using System.Collections.Generic;

/// <summary>
/// List of events that can be fired in the game (Might be separated in domains later)
/// </summary>
public static class EventHandler {
    /// <summary>
    /// Event that fires any time the player moves or stops moving
    /// </summary>
    public static event Action<float, float> PlayerMovementEvent;
    public static void CallMovementEvent(float inputX, float inputY)
    {
        if (PlayerMovementEvent != null)
        {
            PlayerMovementEvent(inputX, inputY);
        }
    }

    /// <summary>
    /// Event that fires any time an inventory changes
    /// </summary>
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryChangeEvent;
    public static void CallInventoryChangeEvent(InventoryLocation location, List<InventoryItem> inventory)
    {
        if (InventoryChangeEvent != null)
        {
            InventoryChangeEvent(location, inventory);
        }
    }

    /// <summary>
    /// Event that fires any time the current scene is about to be faded out for an unload
    /// </summary>
    public static event Action BeforeSceneUnloadFadeOutEvent;
    public static void CallBeforeSceneUnloadFadeOutEvent() {
        if (BeforeSceneUnloadFadeOutEvent != null) {
            BeforeSceneUnloadFadeOutEvent();
        }
    }

    /// <summary>
    /// Event that fires any time the current scene is about to be unloaded
    /// </summary>
    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        if (BeforeSceneUnloadEvent != null)
        {
            BeforeSceneUnloadEvent();
        }
    }

    /// <summary>
    /// Event that fires any time the current scene is about to be loaded
    /// </summary>
    public static event Action AfterSceneLoadEvent;
    public static void CallAfterSceneLoadEvent()
    {
        if (AfterSceneLoadEvent != null)
        {
            AfterSceneLoadEvent();
        }
    }

    /// <summary>
    /// Event that fires any time the current scene is about to faded in after a load
    /// </summary>
    public static event Action AfterSceneLoadFadeInEvent;
    public static void CallAfterSceneLoadFadeInEvent()
    {
        if (AfterSceneLoadFadeInEvent != null)
        {
            AfterSceneLoadFadeInEvent();
        }
    }

}
