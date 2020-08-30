using UnityEngine;

/// <summary>
/// Main player behavior class. Might be separated by domain in the future
/// </summary>
public class Player : MonoBehaviour {
    // ********************* Properties *************************** //

    /// <summary>
    /// X input for movement
    /// </summary>
    private float inputX = 0;
    /// <summary>
    /// Y input for movement
    /// </summary>
    private float inputY = 0;

    /// <summary>
    /// Rigidbody for physics operations
    /// </summary>
    private Rigidbody2D rb2D;

    /// <summary>
    /// Speed of movement in units per second
    /// </summary>
    private float movementSpeed;

    /// <summary>
    /// Last frame's input X
    /// </summary>
    private float prevInputX;

    /// <summary>
    /// Last frame's input Y
    /// </summary>
    private float prevInputY;

    // ********************* Unity Methods *************************** //

    /// <summary>
    /// Initialize internal parameters
    /// </summary>
    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update each frame
    /// </summary>
    private void Update() {
        PlayerMovementInput();

        if (prevInputX != inputX || prevInputY != inputY) {
            EventHandler.CallMovementEvent(inputX, inputY);
        }
        PlayerMovement();
    }

    // ********************* Private Methods *************************** //

    /// <summary>
    /// Get the player input
    /// </summary>
    private void PlayerMovementInput() {
        prevInputX = inputX;
        prevInputY = inputY;
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = inputX == 0 ? Input.GetAxisRaw("Vertical") : 0;
        movementSpeed = (inputX != 0 || inputY != 0) ? Settings.PlayerVariables.movementSpeed : 0;
    }

    /// <summary>
    /// Move the player using physics
    /// </summary>
    private void PlayerMovement() {
        float moveSpeed = movementSpeed;
        Vector2 move = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
        rb2D.velocity = move;
    }
}
