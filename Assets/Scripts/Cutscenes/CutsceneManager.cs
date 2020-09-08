using System.Collections.Generic;

public class CutsceneManager : SingletonMonoBehaviour<CutsceneManager> {
    private Dictionary<int, CutsceneDetails> cutscenes;
    private CutsceneDetails playingCutscene;
    private int stepIndex;

    public SO_CutsceneList cutsceneList;
    public bool IsPlayingCutscene { get { return playingCutscene != null; } }

    protected override void Awake() {
        base.Awake();
        CreateCutsceneDictionary();
        ResetPlaybackVars();
    }

    private void OnEnable() {
        EventHandler.CutsceneActionEndEvent += OnCutsceneActionEnd;
    }

    private void OnDisable() {
        EventHandler.CutsceneActionEndEvent -= OnCutsceneActionEnd;
    }

    public CutsceneDetails GetCutsceneDetails(int code) {
        CutsceneDetails res;
        return cutscenes.TryGetValue(code, out res) ? res : null;
    }

    public void PlayCutscene(int code) {
        if (IsPlayingCutscene) return;
        CutsceneDetails detail = GetCutsceneDetails(code);
        if (detail == null) return;

        EventHandler.CallCutsceneStartEvent();
        playingCutscene = detail;
        CutsceneStep();
    }

    private void CutsceneStep() {
        ICutsceneAction action = playingCutscene.actions[stepIndex];
        action.Execute();
    }

    private void ResetPlaybackVars() {
        playingCutscene = null;
        stepIndex = 0;
    }

    private void CreateCutsceneDictionary() {
        cutscenes = new Dictionary<int, CutsceneDetails>();
        foreach (CutsceneData data in cutsceneList.cutscenes) {
            cutscenes.Add(data.cutsceneCode, data.cutscene);
        }
    }

    private void OnCutsceneActionEnd() {
        stepIndex++;
        if (stepIndex >= playingCutscene.actions.Count) {
            EventHandler.CallCutsceneEndEvent();
            ResetPlaybackVars();
        } else {
            CutsceneStep();
        }
    }
}