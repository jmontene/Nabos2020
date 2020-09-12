using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager> {
    private Dictionary<PopupType, GameObject> popups;
    public List<PopupDetails> popupList;

    [Header("Dialogues")]
    public CanvasGroup dialogueUICanvas;
    public TypewriterText typewriter;

    [Header("Popups")]
    public CanvasGroup popupParent;

    [HideInInspector] public bool IsUIBlocking;

    private GameObject currentPopup;

    protected override void Awake() {
        base.Awake();
        dialogueUICanvas.alpha = 0f;
        popupParent.alpha = 0f;

        popups = new Dictionary<PopupType, GameObject>();
        foreach(PopupDetails detail in popupList) {
            popups.Add(detail.popupType, detail.popupPrefab);
        }
    }

    public void ShowPopup(PopupType popupType) {
        popupParent.alpha = 1f;
        currentPopup = Instantiate(popups[popupType], popupParent.transform);
    }

    private void ShowYesNoPopup(string mainText) {
        PopupYesNo comp = currentPopup.GetComponent<PopupYesNo>();
    }
}