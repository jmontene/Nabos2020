using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager> {
    private Dictionary<PopupType, GameObject> popups;

    [Header("Dialogues")]
    public CanvasGroup dialogueUICanvas;
    public TypewriterText typewriter;

    [Header("Popups")]
    public CanvasGroup popupParent;
    public List<PopupDetails> popupList;

    [HideInInspector] public bool IsUIBlocking;

    private GameObject currentPopup;

    protected override void Awake() {
        base.Awake();
        dialogueUICanvas.alpha = 0f;
        popupParent.alpha = 0f;
        IsUIBlocking = false;

        popups = new Dictionary<PopupType, GameObject>();
        foreach(PopupDetails detail in popupList) {
            popups.Add(detail.popupType, detail.popupPrefab);
        }
    }
    public void ShowYesNoPopup(string mainText, Action yesCallback, Action noCallback) {
        ShowPopup(PopupType.YesNo);
        PopupYesNo comp = currentPopup.GetComponent<PopupYesNo>();
        comp.text.SetText(mainText);
        comp.SetCallbacks(yesCallback, noCallback);
    }

    public void ShowModalPopup(string mainText, Action closeCallback) {
        ShowPopup(PopupType.Modal);
        PopupModal comp = currentPopup.GetComponent<PopupModal>();
        comp.text.SetText(mainText);
        comp.onClose = closeCallback;
    }

    public void ClosePopup() {
        Destroy(currentPopup);
        popupParent.alpha = 0f;
        IsUIBlocking = false;
        EventHandler.CallPopupCloseEvent();
    }

    private void ShowPopup(PopupType popupType) {
        IsUIBlocking = true;
        popupParent.alpha = 1f;
        currentPopup = Instantiate(popups[popupType], popupParent.transform);
    }

    
}