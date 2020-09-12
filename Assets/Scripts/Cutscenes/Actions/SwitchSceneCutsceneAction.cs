[System.Serializable]
public class SwitchSceneCutsceneAction : BaseCutsceneAction {
    public SceneName sceneName;
    public string spawnName;
    public bool endOnLoad = false;

    public override string GetEditorName() {
        return "Switch Scene Action";
    }

    public override void Execute() {
        if (endOnLoad) {
            EventHandler.AfterSceneLoadEvent += OnSceneLoad;
        } else {
            EventHandler.AfterSceneLoadFadeInEvent += OnSceneLoadFadeIn;
        }
        Player.Instance.currentSpawnPointName = spawnName;
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