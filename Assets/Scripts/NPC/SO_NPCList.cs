using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game npc database
/// </summary>
[CreateAssetMenu(fileName = "so_NPCList", menuName = "Nabos/NPC/NPCList")]
public class SO_NPCList : ScriptableObject {
    [SerializeField]
    public List<NPCDetails> npcDetails;
}