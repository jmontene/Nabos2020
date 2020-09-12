using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupYesNo : MonoBehaviour {
    public Image yesSelect;
    public Image noSelect;
    public TextMeshProUGUI text;
    public bool yesSelected;

    private Action yesCallback;
    private Action noCallback;

    protected void Awake() {
        SetSelected(true);
    }

    protected void Update() {
        float dir = Input.GetAxisRaw("Horizontal");
        if (dir != 0f) {
            SetSelected(dir < 0f);
        }

        if (Input.GetButtonDown("Interact")) {
            if (yesSelected) {
                yesCallback?.Invoke();
            } else {
                noCallback?.Invoke();
            }
            UIManager.Instance.ClosePopup();
        }
    }

    public void SetSelected(bool yes) {
        yesSelected = yes;
        yesSelect.color = new Color(0f, 0f, 0f, yes ? 1f : 0f);
        noSelect.color = new Color(0f, 0f, 0f, yes ? 0f : 1f);
    }

    public void SetCallbacks(Action yes, Action no) {
        yesCallback = yes;
        noCallback = no;
    }
}