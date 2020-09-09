using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_SocialLinkList", menuName = "Nabos/NPC/SocialLinkList")]
public class SO_SocialLinkList : ScriptableObject {
    public List<SocialLinkDetails> socialLinks;
}