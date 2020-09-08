using System.Collections;
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

    private Vector2 direction;

    [HideInInspector] public bool inputEnabled = true;
    [HideInInspector] public string currentSpawnPointName = "";

    [Header("Interactions")]
    public Transform interactOrigin;
    public float interactionDistance;
    public LayerMask interactionMask;

    // ********************* Unity Methods *************************** //

    /// <summary>
    /// Initialize internal parameters
    /// </summary>
    protected void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        currentSpawnPointName = "Spawn1";
        direction = Vector2.down;
    }

    /// <summary>
    /// Update each frame
    /// </summary>
    private void Update() {
        if (inputEnabled) {
            PlayerTestInput();
            PlayerMovementInput();
            PlayerActionsInput();
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
        EventHandler.BeforeSceneUnloadFadeOutEvent += OnBeforeSceneUnloadFadeOut;
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoaded;
        EventHandler.AfterSceneLoadFadeInEvent += OnAfterSceneFadedIn;
        EventHandler.DialogueStartEvent += OnDialogueStart;
        EventHandler.DialogueEndEvent += OnDialogueEnd;
        EventHandler.CutsceneStartEvent += OnCutsceneStart;
        EventHandler.CutsceneEndEvent += OnCutsceneEnd;
    }

    private void OnDisable() {
        EventHandler.BeforeSceneUnloadFadeOutEvent -= OnBeforeSceneUnloadFadeOut;
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoaded;
        EventHandler.AfterSceneLoadFadeInEvent -= OnAfterSceneFadedIn;
        EventHandler.DialogueStartEvent -= OnDialogueStart;
        EventHandler.DialogueEndEvent -= OnDialogueEnd;
        EventHandler.CutsceneStartEvent -= OnCutsceneStart;
        EventHandler.CutsceneEndEvent -= OnCutsceneEnd;
    }

    // ********************* Private Methods *************************** //

    private void PlayerTestInput() {
        if (Input.GetKeyDown(KeyCode.L)) {
            currentSpawnPointName = "Spawn1";
            SceneController.Instance.FadeAndLoadScene(SceneName.Scene001_Test.ToString());
        } else if (Input.GetKeyDown(KeyCode.T)) {
            currentSpawnPointName = "Spawn1";
            SceneController.Instance.DebugPassTime();
        }
    }

    private void OnBeforeSceneUnloadFadeOut() {
        inputEnabled = false;
    }

    private void OnAfterSceneFadedIn() {
        inputEnabled = !CutsceneManager.Instance.IsPlayingCutscene;
    }

    private void OnAfterSceneLoaded() {
        transform.position = SceneController.Instance.FindSpawnPosition(currentSpawnPointName);
    }
    private void OnDialogueStart() {
        inputEnabled = false;
    }

    private void OnDialogueEnd() {
        StartCoroutine(OnDialogueEndRoutine());
    }
    private IEnumerator OnDialogueEndRoutine() {
        yield return new WaitForSeconds(0.2f);
        inputEnabled = !CutsceneManager.Instance.IsPlayingCutscene;
    }

    private void OnCutsceneStart() {
        inputEnabled = false;
    }

    private void OnCutsceneEnd() {
        inputEnabled = true;
    }

    /// <summary>
    /// Get the player input
    /// </summary>
    private void PlayerMovementInput() {
        prevInputX = inputX;
        prevInputY = inputY;
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = inputX == 0 ? Input.GetAxisRaw("Vertical") : 0;
        bool hasDirection = (inputX != 0 || inputY != 0);
        if (hasDirection) {
            direction.Set(inputX, inputY);
        }
        movementSpeed = hasDirection ? Settings.PlayerVariables.movementSpeed : 0;
    }

    /// <summary>
    /// Move the player using physics
    /// </summary>
    private void PlayerMovement() {
        float moveSpeed = movementSpeed;
        Vector2 move = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
        rb2D.velocity = move;
    }

    private void PlayerActionsInput() {
        if (Input.GetButtonDown("Interact")) {
            RaycastHit2D hit = Physics2D.Raycast(interactOrigin.position, direction, interactionDistance, interactionMask);
            if (hit) {
                PlayerInteractionTrigger interaction = hit.collider.GetComponentInParent<PlayerInteractionTrigger>();
                if (interaction != null) {
                    interaction.OnPlayerInteract(this);
                }
            }
        }
    }
}
