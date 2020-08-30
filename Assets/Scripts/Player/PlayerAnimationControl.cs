using UnityEngine;

/// <summary>
/// This class controls animations for the player and subcomponents
/// </summary>
public class PlayerAnimationControl : MonoBehaviour {
    /// <summary>
    /// The animator to control
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Set up internals
    /// </summary>
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Set up events and other things that should be destroyed on disable
    /// </summary>
    private void OnEnable() {
        EventHandler.PlayerMovementEvent += OnPlayerMovement;
    }

    /// <summary>
    /// Tear down events and other things that should be destroyed on disable
    /// </summary>
    private void OnDisable() {
        EventHandler.PlayerMovementEvent -= OnPlayerMovement;
    }

    /// <summary>
    /// Callback for when the player movement changes
    /// </summary>
    /// <param name="inputX">X input</param>
    /// <param name="inputY">Y input</param>
    private void OnPlayerMovement(float inputX, float inputY) {
        bool wasMoving = animator.GetBool(Settings.PlayerAnimationKeys.Moving);
        bool isMoving = inputX != 0 || inputY != 0;
        animator.SetBool(Settings.PlayerAnimationKeys.Moving, isMoving);

        if (isMoving){
            animator.SetFloat(Settings.PlayerAnimationKeys.xDir, inputX);
            animator.SetFloat(Settings.PlayerAnimationKeys.yDir, inputY);
        }
        
    }
}
