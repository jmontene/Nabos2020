using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "so_CutsceneList", menuName = "Nabos/Cutscenes/CutsceneList")]
public class SO_CutsceneList : ScriptableObject {
    public List<CutsceneData> cutscenes;
}