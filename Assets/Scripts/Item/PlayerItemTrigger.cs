/// <summary>
/// Interface for items that trigger when the player enters a trigger inside them
/// </summary>
public interface PlayerItemTrigger {
    void OnPlayerEnter(Player player);
    void OnPlayerExit(Player player);
}
