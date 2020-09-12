using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SocialLinkEXPUnit {
    public int pointsForNextLevel;
}

[System.Serializable]
public class SocialLinkDetails {
    public int npcCode;
    public List<SocialLinkEXPUnit> expUnits;

    public SocialLinkDetails() {
        expUnits = new List<SocialLinkEXPUnit>();
    }

    public void DebugPrint() {
        Debug.Log($"Npc Code: {npcCode}");
        for (int i = 0; i < expUnits.Count; ++i) {
            Debug.Log($"Level {i + 1}: {expUnits[i].pointsForNextLevel} points for next level");
        }
    }
}