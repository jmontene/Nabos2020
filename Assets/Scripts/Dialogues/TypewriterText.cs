using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TypewriterText : MonoBehaviour {
    private TextMeshProUGUI textMesh;

    public float textSpeed = 0.07f;
    public string textToReveal;
    [HideInInspector] public bool running;

    private void Awake() {
        textMesh = GetComponent<TextMeshProUGUI>();
        running = false;
    }

    public IEnumerator ShowText(string text) {
        running = true;
        textMesh.text = "";
        string curText = "";
        for (int i = 0; i < text.Length; ++i) {
            while(char.IsWhiteSpace(text[i])) { 
                curText += text[i];
                ++i;
            }
            curText += text[i];
            textMesh.text = curText;
            yield return new WaitForSeconds(textSpeed);
        }
        running = false;
    }
}
