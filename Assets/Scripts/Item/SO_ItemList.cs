using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game item database
/// </summary>
[CreateAssetMenu(fileName="so_ItemList", menuName="Nabos/Item/ItemList")]
public class SO_ItemList : ScriptableObject {
    [SerializeField]
    public List<ItemDetails> itemDetails;
}
