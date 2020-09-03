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

    [HideInInspector] public bool inputEnabled = true;
    [HideInInspector] public string currentSpawnPointName = "";

    // ********************* Unity Methods *************************** //

    /// <summary>
    /// Initialize internal parameters
    /// </summary>
    protected void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        currentSpawnPointName = "Spawn1";
    }

    /// <summary>
    /// Update each frame
    /// </summary>
    private void Update() {
        PlayerTestInput();

        if (inputEnabled){
            PlayerMovementInput();
        } else {
            inputX = 0;
            inputY = 0;
        }
        if (prevInputX != inputX || prevInputY != inputY) {
            EventHandler.CallMovementEvent(inputX, inputY);
        }
        PlayerMovement();
    }

    private void OnEnable() {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnload;
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoaded;
        EventHandler.AfterSceneLoadFadeInEvent += OnAfterSceneFadedIn;
    }

    private void OnDisable(){
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnload;
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoaded;
        EventHandler.AfterSceneLoadFadeInEvent -= OnAfterSceneFadedIn;
    }

    // ********************* Private Methods *************************** //

    private void PlayerTestInput() {
        if (Input.GetKeyDown(KeyCode.L)) {
            currentSpawnPointName = "Spawn1";
            SceneController.Instance.FadeAndLoadScene(SceneName.Scene001_Test.ToString());
        }
    }

    private void OnBeforeSceneUnload() {
        inputEnabled = false;
    }

    private void OnAfterSceneFadedIn() {
        inputEnabled = true;
    }

    private void OnAfterSceneLoaded() {
        transform.position = SceneController.Instance.FindSpawnPosition(currentSpawnPointName);
    }

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
