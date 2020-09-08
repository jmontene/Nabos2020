[System.Serializable]
public class DialogueCutsceneAction : BaseCutsceneAction {
    public int dialogueCode;

    public override void Execute() {
        EventHandler.DialogueEndEvent += OnEndDialogue;
        DialogueManager.Instance.StartDialogue(dialogueCode);
    }

    private void OnEndDialogue() {
        EventHandler.DialogueEndEvent -= OnEndDialogue;
        EventHandler.CallCutsceneActionEndEvent();
    }
}