using UnityEngine;

public class InteractableDoor : MonoBehaviour, PlayerInteractionTrigger {
    public string openText;
    public string closedText;
    public SceneName targetRoom;
    public string spawnName;
    public bool open;

    public void OnPlayerInteract(Player player) {
        UIManager.Instance.ShowYesNoPopup(openText, OnDoorOpen, null);
    }

    private void OnDoorOpen() {
        if (open) {
            Player.Instance.currentSpawnPointName = spawnName;
            SceneController.Instance.FadeAndLoadScene(targetRoom.ToString());
        } else {
            EventHandler.PopupCloseEvent += OnPopupClosed;
        }
    }

    private void OnPopupClosed() {
        EventHandler.PopupCloseEvent -= OnPopupClosed;
        UIManager.Instance.ShowModalPopup(closedText, null);
    }
}