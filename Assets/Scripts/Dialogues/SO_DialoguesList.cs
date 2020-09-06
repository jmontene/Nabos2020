using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_DialogueList", menuName = "Nabos/Dialogues/DialogueList")]
public class SO_DialoguesList : ScriptableObject {
    public List<DialogueDetails> dialogues;
}