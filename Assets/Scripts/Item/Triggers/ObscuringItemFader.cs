using System.Collections;
using UnityEngine;

/// <summary>
/// Fades objects that obscure the player
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class ObscuringItemFader : MonoBehaviour, PlayerItemTrigger {
    /// <summary>
    /// The renderer to fade
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Init internal variables
    /// </summary>
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Fade out the object
    /// </summary>
    public void FadeOut() {
        StartCoroutine(FadeOutRoutine());
    }

    /// <summary>
    /// Fade in the object
    /// </summary>
    public void FadeIn() {
        StartCoroutine(FadeInRoutine());
    }

    /// <summary>
    /// Coroutine for fadeout
    /// </summary>
    /// <returns>Nothing</returns>
    private IEnumerator FadeOutRoutine() {
        float curAlpha = spriteRenderer.color.a;
        float distance = curAlpha - Settings.FadeOutConstants.targetAlpha;

        while(curAlpha - Settings.FadeOutConstants.targetAlpha > 0.01f) {
            curAlpha -= distance / Settings.FadeOutConstants.fadeOutSeconds * Time.deltaTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, curAlpha);
            yield return null;
        }

        spriteRenderer.color = new Color(1f, 1f, 1f, Settings.FadeOutConstants.targetAlpha);
    }

    /// <summary>
    /// Coroutine for fadein
    /// </summary>
    /// <returns>Nothing</returns>
    private IEnumerator FadeInRoutine()
    {
        float curAlpha = spriteRenderer.color.a;
        float distance = 1f - curAlpha;

        while (1f - curAlpha > 0.01f)
        {
            curAlpha += distance / Settings.FadeOutConstants.fadeInSeconds * Time.deltaTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, curAlpha);
            yield return null;
        }

        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    public void OnPlayerEnter(Player player) {
        FadeOut();
    }

    public void OnPlayerExit(Player player) {
        FadeIn();
    }
}
