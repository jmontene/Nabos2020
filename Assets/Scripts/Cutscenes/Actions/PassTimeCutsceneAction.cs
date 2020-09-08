[System.Serializable]
public class PassTimeCutsceneAction : BaseCutsceneAction {
    public override void Execute(){
        TimeManager.Instance.NextSlot();
        EventHandler.CallCutsceneActionEndEvent();
    }
}