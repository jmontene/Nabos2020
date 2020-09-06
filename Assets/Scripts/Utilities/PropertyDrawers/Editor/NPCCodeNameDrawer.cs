using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(NPCCodeNameAttribute))]
public class NPCCodeNameDrawer : PropertyDrawer {
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return EditorGUI.GetPropertyHeight(property) * 2f;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType == SerializedPropertyType.Integer) {
            EditorGUI.BeginChangeCheck();

            float halfH = position.height / 2;
            int newValue = EditorGUI.IntField(new Rect(position.x, position.y, position.width, halfH), label, property.intValue);
            EditorGUI.LabelField(new Rect(position.x, position.y + halfH, position.width, halfH), "NPC Name", GetNPCName(property.intValue));

            if (EditorGUI.EndChangeCheck()) {
                property.intValue = newValue;
            }
        }

        EditorGUI.EndProperty();
    }

    private string GetNPCName(int code) {
        SO_NPCList npcList = AssetDatabase.LoadAssetAtPath<SO_NPCList>("Assets/Databases/so_NPCList.asset");
        List<NPCDetails> list = npcList.npcDetails;
        NPCDetails detail = list.Find(x => x.npcCode == code);

        return detail != null ? detail.npcName : "NPC_NOT_FOUND";
    }
}
