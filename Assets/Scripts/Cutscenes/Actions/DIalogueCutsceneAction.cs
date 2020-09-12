[System.Serializable]
public class DialogueCutsceneAction : BaseCutsceneAction {
    public int dialogueCode;

    public override string GetEditorName() {
        return "Dialogue Action";
    }

    public override void Execute() {
        EventHandler.DialogueEndEvent += OnEndDialogue;
        DialogueManager.Instance.StartDialogue(dialogueCode);
    }

    private void OnEndDialogue() {
        EventHandler.DialogueEndEvent -= OnEndDialogue;
        EventHandler.CallCutsceneActionEndEvent();
    }
}