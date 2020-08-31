using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager> {
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    public List<InventoryItem>[] inventoryLists;
    public int[] inventoryListCapacityIntArray;

    [SerializeField]
    private SO_ItemList itemList = null;

    protected override void Awake() {
        base.Awake();
        CreateInventoryLists();
        CreateItemDetailsDictionary();
    }

    public ItemDetails GetItemDetails(int itemCode) {
        ItemDetails res;
        return itemDetailsDictionary.TryGetValue(itemCode, out res) ? res : null;
    }

    /// <summary>
    /// Add an item to the inventory location
    /// </summary>
    /// <param name="inventoryLocation">Inventory location</param>
    /// <param name="item">Item to add</param>
    public void AddItem(InventoryLocation inventoryLocation, Item item) {
        int itemCode = item.ItemCode;
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);
        AddItemAtPosition(inventoryList, itemCode, itemPosition < 0 ? -1 : itemPosition);

        EventHandler.CallInventoryChangeEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    /// <summary>
    /// Returns the item position in the inventory list if it exists
    /// </summary>
    /// <param name="location">Location to search in</param>
    /// <param name="itemCode">Item code</param>
    /// <returns>Item position</returns>
    public int FindItemInInventory(InventoryLocation location, int itemCode) {
        List<InventoryItem> inventoryList = inventoryLists[(int)location];
        int res = inventoryList.FindIndex(x => x.itemCode == itemCode);
        return res >= 0 ? res : -1;
    }

    /// <summary>
    /// Adds an item at a position in an inventory list (or at the end if it does not exist)
    /// </summary>
    /// <param name="inventoryList">The list to modify</param>
    /// <param name="itemCode">The code of the item to add</param>
    /// <param name="position">Position to add in</param>
    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int position = -1) {
        InventoryItem inventoryItem = new InventoryItem();
        inventoryItem.itemCode = itemCode;

        if (position < 0) {
            inventoryItem.itemQuantity = 1;
            inventoryList.Add(inventoryItem);
        } else {
            inventoryItem.itemQuantity = inventoryList[position].itemQuantity + 1;
            inventoryList[position] = inventoryItem;
        }

        DebugPrintInventoryList(inventoryList);
    }

    /// <summary>
    /// Populates the item details dictionary
    /// </summary>
    private void CreateItemDetailsDictionary() {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach(ItemDetails details in itemList.itemDetails) {
            itemDetailsDictionary.Add(details.itemCode, details);
        }
    }

    private void CreateInventoryLists() {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.Count];
        for (int i=0; i < inventoryLists.Length; ++i) {
            inventoryLists[i] = new List<InventoryItem>();
        }

        inventoryListCapacityIntArray = new int[(int)InventoryLocation.Count];
        inventoryListCapacityIntArray[(int)InventoryLocation.Player] = Settings.PlayerVariables.initialInventoryCapacity;
    }

    private void DebugPrintInventoryList(List<InventoryItem> list) {
        foreach(InventoryItem item in list) {
            Debug.Log("Item Name: " + InventoryManager.Instance.GetItemDetails(item.itemCode).itemName);
            Debug.Log("Item Quantity: " + item.itemQuantity);
        }
        Debug.Log("*********************************************************");
    }
}
