using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(ItemCodeNameAttribute))]
public class ItemCodeNameDrawer : PropertyDrawer {
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return EditorGUI.GetPropertyHeight(property) * 2f;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType == SerializedPropertyType.Integer) {
            EditorGUI.BeginChangeCheck();

            float halfH = position.height / 2;
            int newValue = EditorGUI.IntField(new Rect(position.x, position.y, position.width, halfH), label, property.intValue);
            EditorGUI.LabelField(new Rect(position.x, position.y + halfH, position.width, halfH), "Item Name", GetItemName(property.intValue));

            if (EditorGUI.EndChangeCheck()) {
                property.intValue = newValue;
            }
        }

        EditorGUI.EndProperty();
    }

    private string GetItemName(int code) {
        SO_ItemList itemList = AssetDatabase.LoadAssetAtPath<SO_ItemList>("Assets/Databases/so_ItemList.asset");
        List<ItemDetails> list = itemList.itemDetails;
        ItemDetails itemDetail = list.Find(x => x.itemCode == code);

        return itemDetail != null ? itemDetail.itemName : "ITEM_NOT_FOUND";
    }
}
