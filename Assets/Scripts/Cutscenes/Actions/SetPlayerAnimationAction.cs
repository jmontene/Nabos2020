using UnityEngine;

[System.Serializable]
public class SetPlayerAnimationAction : BaseCutsceneAction {
    public AnimationParameterType parameterType;
    public PlayerAnimationParameterNames parameterName;

    public bool boolValue;
    public int intValue;
    public float floatValue;

    public override string GetEditorName() {
        return "Set Player Animation";
    }

    public override void Execute() {
        Animator anim = Player.Instance.bodyAnimator;
        switch(parameterType) {
            case AnimationParameterType.Bool:
                anim.SetBool(parameterName.ToString(), boolValue);
                break;
            case AnimationParameterType.Int:
                anim.SetInteger(parameterName.ToString(), intValue);
                break;
            case AnimationParameterType.Trigger:
                anim.SetTrigger(parameterName.ToString());
                break;
            case AnimationParameterType.Float:
                anim.SetFloat(parameterName.ToString(), floatValue);
                break;
        }
        EventHandler.CallCutsceneActionEndEvent();
    }
}