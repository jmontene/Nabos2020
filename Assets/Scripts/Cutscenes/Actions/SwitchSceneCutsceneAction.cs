[System.Serializable]
public class SwitchSceneCutsceneAction : BaseCutsceneAction {
    public SceneName sceneName;
    public bool endOnLoad = false;

    public override void Execute() {
        if (endOnLoad) {
            EventHandler.AfterSceneLoadEvent += OnSceneLoad;
        } else {
            EventHandler.AfterSceneLoadFadeInEvent += OnSceneLoadFadeIn;
        }
        SceneController.Instance.FadeAndLoadScene(sceneName.ToString());
    }

    private void OnSceneLoadFadeIn() {
        EventHandler.AfterSceneLoadFadeInEvent -= OnSceneLoadFadeIn;
        EventHandler.CallCutsceneActionEndEvent();
    }

    private void OnSceneLoad() {
        EventHandler.AfterSceneLoadEvent -= OnSceneLoad;
        EventHandler.CallCutsceneActionEndEvent();
    }
}