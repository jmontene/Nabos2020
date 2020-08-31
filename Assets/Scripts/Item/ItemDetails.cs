using UnityEngine;

/// <summary>
/// Detail for items
/// </summary>
[System.Serializable]
public class ItemDetails {
    public int itemCode;
    public string itemName;
    public ItemType itemType;
    public string itemDescription;
    public Sprite itemSprite;

    public bool canBePickedUp;
}
