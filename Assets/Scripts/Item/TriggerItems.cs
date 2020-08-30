using UnityEngine;

public class TriggerItems : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerItemTrigger[] triggers = collision.gameObject.GetComponentsInChildren<PlayerItemTrigger>();
        for (int i=0; i < triggers.Length; ++i) {
            triggers[i].OnPlayerEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        PlayerItemTrigger[] triggers = collision.gameObject.GetComponentsInChildren<PlayerItemTrigger>();
        for (int i = 0; i < triggers.Length; ++i) {
            triggers[i].OnPlayerExit();
        }
    }
}
