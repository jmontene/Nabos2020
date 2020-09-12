using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_RoomList", menuName = "Nabos/Scene/RoomList")]
public class SO_RoomList : ScriptableObject {
    public List<SceneDetails> rooms;
}