using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SO_SocialLinkList))]
public class SocialLinkListEditor : Editor {
    protected List<bool> collapse;
    protected List<List<bool>> levelCollapse;

    protected void OnEnable() {
        SO_SocialLinkList obj = serializedObject.targetObject as SO_SocialLinkList;
        collapse = new List<bool>();
        levelCollapse = new List<List<bool>>();
        if (obj.socialLinks == null) {
            obj.socialLinks = new List<SocialLinkDetails>();
        }
        for (int i = 0; i < obj.socialLinks.Count; i++) {
            SocialLinkDetails sl = obj.socialLinks[i];
            collapse.Add(false);
            levelCollapse.Add(new List<bool>());
            for (int j = 0; j < sl.expUnits.Count; ++j) {
                levelCollapse[i].Add(false);
            }
        }
    }

    public override void OnInspectorGUI() {
        SO_SocialLinkList obj = serializedObject.targetObject as SO_SocialLinkList;
        for (int i=0; i<obj.socialLinks.Count; ++i) {
            SerializedProperty property = serializedObject.FindProperty($"socialLinks.Array.data[{i}]");
            if (property != null) {
                SocialLinkDetails sl = obj.socialLinks[i];
                if (i >= collapse.Count) {
                    collapse.Add(false);
                }

                EditorGUILayout.BeginHorizontal();
                collapse[i] = EditorGUILayout.Foldout(collapse[i], GetNPCName(sl.npcCode));
                if (GUILayout.Button("X")) {
                    obj.socialLinks.RemoveAt(i);
                    collapse.RemoveAt(i);
                    EditorGUILayout.EndHorizontal();
                    continue;
                }
                EditorGUILayout.EndHorizontal();

                if (collapse[i]) {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.PropertyField(property.FindPropertyRelative("npcCode"));

                    for(int j=0;j<sl.expUnits.Count;++j) {
                        SerializedProperty expUnitsProp = property.FindPropertyRelative($"expUnits.Array.data[{j}]");
                        if (expUnitsProp != null) {
                            if (i >= levelCollapse.Count) {
                                levelCollapse.Add(new List<bool>());
                            }
                            if (j >= levelCollapse[i].Count) {
                                levelCollapse[i].Add(false);
                            }
                            levelCollapse[i][j] = EditorGUILayout.Foldout(levelCollapse[i][j], $"Level {j + 1}");
                            if (levelCollapse[i][j]) {

                                EditorGUILayout.BeginHorizontal();
                                SocialLinkEXPUnit unit = new SocialLinkEXPUnit();
                                EditorGUILayout.LabelField("Points for next level");
                                unit.pointsForNextLevel = EditorGUILayout.IntField(sl.expUnits[j].pointsForNextLevel);
                                EditorGUILayout.EndHorizontal();

                                sl.expUnits[j] = unit;
                            }
                        }
                    }

                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button("Add Social Link Level")) {
                        SocialLinkEXPUnit unit = new SocialLinkEXPUnit
                        {
                            pointsForNextLevel = 0
                        };
                        obj.socialLinks[i].expUnits.Add(unit);
                    }
                    if (obj.socialLinks[i].expUnits.Count >= 1) {
                        if (GUILayout.Button("Remove Social Link Level")) {
                            obj.socialLinks[i].expUnits.RemoveAt(obj.socialLinks[i].expUnits.Count - 1);
                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUI.indentLevel--;
                }
                
            }
        }

        if (GUILayout.Button("Add Social Link")) {
            obj.socialLinks.Add(new SocialLinkDetails());
        }

        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
        EditorUtility.SetDirty(obj);
    }

    private string GetNPCName(int code) {
        SO_NPCList npcList = AssetDatabase.LoadAssetAtPath<SO_NPCList>("Assets/Databases/so_NPCList.asset");
        List<NPCDetails> list = npcList.npcDetails;
        NPCDetails detail = list.Find(x => x.npcCode == code);

        return detail != null ? detail.npcName : "NPC_NOT_FOUND";
    }
}