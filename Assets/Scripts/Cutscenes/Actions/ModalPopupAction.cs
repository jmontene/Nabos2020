[System.Serializable]
public class ModalPopupAction : BaseCutsceneAction {
    public string popupText;

    public override string GetEditorName() {
        return "Modal Popup Action";
    }

    public override void Execute() {
        UIManager.Instance.ShowModalPopup(popupText, OnPopupClose);
    }

    private void OnPopupClose() {
        EventHandler.CallCutsceneActionEndEvent();
    }
}