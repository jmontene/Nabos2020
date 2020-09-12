using UnityEngine;
public class NPC : MonoBehaviour, PlayerInteractionTrigger {
    [NPCCodeName]
    [SerializeField]
    private int _npcCode;
    public int NPCCode { get { return _npcCode; } set { _npcCode = value; } }

    private NPCDetails npcDetails;

    private void Start() {
        Init(NPCCode);
    }

    public void Init(int code) {
        npcDetails = NPCManager.Instance.GetNPCDetails(code);
    }

    public void OnPlayerInteract(Player player) {
        UIManager.Instance.ShowYesNoPopup("NPC has shown a popup?", OnYes, OnNo);
    }

    private void OnYes() {
        Debug.Log("Yes selected");
    }

    private void OnNo() {
        Debug.Log("No selected");
    }
}