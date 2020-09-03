using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerSceneTeleport : MonoBehaviour, PlayerItemTrigger
{
    [SerializeField] private SceneName targetScene;
    [SerializeField] private string spawnPointName;

    public void OnPlayerEnter(Player player) {
        player.currentSpawnPointName = spawnPointName;
        SceneController.Instance.FadeAndLoadScene(targetScene.ToString());
    }

    public void OnPlayerExit(Player player) {
        //Do Nothing
    }
}
