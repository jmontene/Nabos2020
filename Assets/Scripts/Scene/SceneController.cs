using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : SingletonMonoBehaviour<SceneController> {
    private bool isFading;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private CanvasGroup faderCanvasGroup = null;
    [SerializeField] private Image faderImage = null;
    public SceneName startingScene;

    private string _currentScene;
    public string CurrentScene { get { return _currentScene; } }

    protected IEnumerator Start() {
        faderImage.color = new Color(0f, 0f, 0f, 1f);
        faderCanvasGroup.alpha = 1f;
        yield return StartCoroutine(LoadSceneAndSetActive(startingScene.ToString()));
        EventHandler.CallAfterSceneLoadEvent();
        StartCoroutine(Fade(0f));
        EventHandler.CallAfterSceneLoadFadeInEvent();
    }

    public void FadeAndLoadScene(string sceneName) {
        if (!isFading) {
            StartCoroutine(FadeAndSwitchScenes(sceneName));
        }
    }

    public Vector3 FindSpawnPosition(string name) {
        GameObject spawnParent = GameObject.FindGameObjectWithTag(Tags.SpawnPointParent);
        Transform target = spawnParent.transform.Find(name);
        if (target != null) {
            return target.position;
        } else {
            return spawnParent.transform.position;
        }
    }

    private IEnumerator Fade(float finalAlpha) {
        isFading = true;
        faderCanvasGroup.blocksRaycasts = true;
        float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;
        while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha)) {
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        isFading = false;
        faderCanvasGroup.blocksRaycasts = false;
    }

    private IEnumerator LoadSceneAndSetActive(string sceneName) {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newlyLoadedScene);
        _currentScene = sceneName;
    }

    private IEnumerator FadeAndSwitchScenes(string sceneName) {
        EventHandler.CallBeforeSceneUnloadFadeOutEvent();
        yield return StartCoroutine(Fade(1f));
        EventHandler.CallBeforeSceneUnloadEvent();
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));
        EventHandler.CallAfterSceneLoadEvent();
        yield return StartCoroutine(Fade(0f));
        EventHandler.CallAfterSceneLoadFadeInEvent();
    }

    // Debug Methods
    public void DebugPassTime() {
        TimeManager.Instance.NextSlot();
        TimeManager.Instance.DebugPrint();
        FadeAndLoadScene(CurrentScene);
    }
}
