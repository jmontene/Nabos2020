using System;
using TMPro;
using UnityEngine;

public class PopupModal : MonoBehaviour {
    public TextMeshProUGUI text;
    [HideInInspector] public Action onClose;

    protected void Update() {
        if (Input.GetButtonDown("Interact")) {
            onClose?.Invoke();
            UIManager.Instance.ClosePopup();
        }
    }
}