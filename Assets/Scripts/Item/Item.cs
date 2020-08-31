using UnityEngine;

/// <summary>
/// Item Behaviour
/// </summary>
public class Item : MonoBehaviour, PlayerItemTrigger {
    [ItemCodeName]
    [SerializeField]
    private int _itemCode;
    public int ItemCode { get { return _itemCode;  } set { _itemCode = value; } }

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start() {
        if (ItemCode != -1){
            Init(ItemCode);
        }
    }

    public void Init(int itemCode) {
        ItemCode = itemCode;
        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(ItemCode);
        spriteRenderer.sprite = itemDetails.itemSprite;
    }

    public void OnPlayerEnter(Player player) {
        ItemDetails itemDetail = InventoryManager.Instance.GetItemDetails(ItemCode);
        if (itemDetail != null) {
            if (itemDetail.canBePickedUp) {
                InventoryManager.Instance.AddItem(InventoryLocation.Player, this);
                Destroy(gameObject);
            }
        }
    }

    public void OnPlayerExit(Player player) {
        // Do Nothing
    }
}
