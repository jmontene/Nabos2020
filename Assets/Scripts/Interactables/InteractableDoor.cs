using UnityEngine;

public class InteractableDoor : MonoBehaviour, PlayerInteractionTrigger {
    public string openText;
    public string closedText;
    public SceneName targetRoom;
    public bool open;

    public void OnPlayerInteract(Player player) {
        if (open) {
            SceneController.Instance.FadeAndLoadScene(targetRoom.ToString());
        } else {
            Debug.Log(closedText);
        }
    }
}