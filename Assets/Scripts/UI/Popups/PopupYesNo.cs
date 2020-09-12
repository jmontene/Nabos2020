using UnityEngine;
using UnityEngine.UI;

public class PopupYesNo : MonoBehaviour {
    public Image yesSelect;
    public Image noSelect;
    public bool yesSelected;

    protected void Awake() {
        SetSelected(true);
    }

    protected void Update() {
        float dir = Input.GetAxisRaw("Horizontal");
        if (dir != 0f) {
            SetSelected(dir > 0f);
        }

        if (Input.GetButtonDown("Interact")) {

        }
    }

    public void SetSelected(bool yes) {
        yesSelected = yes;
        yesSelect.color = new Color(1f, 1f, 1f, yes ? 1f : 0f);
        noSelect.color = new Color(1f, 1f, 1f, yes ? 0f : 1f);
    }
}