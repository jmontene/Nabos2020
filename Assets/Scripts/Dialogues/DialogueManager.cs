using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : SingletonMonoBehaviour<DialogueManager> {
    private Dictionary<int, DialogueDetails> dialoguesDictionary;
    private bool runningDialogue;
    private int currentDialogueIndex;
    private DialogueDetails currentDetails;

    public SO_DialoguesList dialoguesList;

    [Header("Dialogue UI")]
    public CanvasGroup dialogueUICanvas;
    public TypewriterText typewriter;

    protected override void Awake() {
        base.Awake();
        CreateDialoguesDictionary();
        runningDialogue = false;
        dialogueUICanvas.alpha = 0f;
    }

    private void Update() {
        if (DialogueUnitFinished() && Input.GetButtonDown("Interact")) {
            NextDialogue();
        }
    }

    public DialogueDetails GetDialogue(int code) {
        DialogueDetails res;
        return dialoguesDictionary.TryGetValue(code, out res) ? res : null;
    }

    public void StartDialogue(int code) {
        DialogueDetails dialogue = GetDialogue(code);
        if (dialogue != null && !runningDialogue) {
            EventHandler.CallDialogueStartEvent();
            runningDialogue = true;
            currentDialogueIndex = -1;
            currentDetails = dialogue;
            dialogueUICanvas.alpha = 1f;
            NextDialogue();
        }
    }

    private bool DialogueUnitFinished() {
        return runningDialogue && !typewriter.running;
    }

    private void NextDialogue() {
        currentDialogueIndex++;
        if (currentDialogueIndex < currentDetails.dialogueUnits.Count) {
            StartCoroutine(typewriter.ShowText(currentDetails.dialogueUnits[currentDialogueIndex].dialogueText));
        } else {
            EndDialogue();
        }
    }

    private void EndDialogue() {
        runningDialogue = false;
        currentDetails = null;
        dialogueUICanvas.alpha = 0f;
        EventHandler.CallDialogueEndEvent();
    }

    private void CreateDialoguesDictionary() {
        dialoguesDictionary = new Dictionary<int, DialogueDetails>();
        foreach (DialogueDetails detail in dialoguesList.dialogues) {
            dialoguesDictionary.Add(detail.dialogueCode, detail);
        }
    }
}