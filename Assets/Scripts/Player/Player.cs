﻿using System.Collections;
using UnityEngine;

/// <summary>
/// Main player behavior class. Might be separated by domain in the future
/// </summary>
public class Player : SingletonMonoBehaviour<Player> {
    // ********************* Properties *************************** //

    /// <summary>
    /// X input for movement
    /// </summary>
    private float inputX = 0;
    /// <summary>
    /// Y input for movement
    /// </summary>
    private float inputY = 0;

    private float staticInputX = 0;
    private float staticInputY = 0;

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

    private bool _inputEnabled;
    public bool InputEnabled {
        get {
            return SceneController.Instance.IsPlayerInputEnabled() && _inputEnabled;
        }
        set {
            _inputEnabled = value;
        }
    }
    [HideInInspector] public string currentSpawnPointName = "";

    [Header("Interactions")]
    public Transform interactOrigin;
    public float interactionDistance;
    public LayerMask interactionMask;

    [Header("Animations")]
    public Animator bodyAnimator;

    // ********************* Unity Methods *************************** //

    /// <summary>
    /// Initialize internal parameters
    /// </summary>
    protected override void Awake() {
        base.Awake();
        rb2D = GetComponent<Rigidbody2D>();
        currentSpawnPointName = "Spawn1";
        direction = Vector2.down;
        _inputEnabled = true;
    }

    /// <summary>
    /// Update each frame
    /// </summary>
    private void Update() {
        if (InputEnabled) {
            PlayerTestInput();
            PlayerMovementInput();
            PlayerActionsInput();
        } else {
            inputX = staticInputX;
            inputY = staticInputY;
        }
        if (prevInputX != inputX || prevInputY != inputY) {
            EventHandler.CallMovementEvent(inputX, inputY);
        }
        PlayerMovement();
    }

    private void OnEnable() {
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoad;
    }

    private void OnDisable() {
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoad;
    }

    public void SetDirection(Direction dir) {
        switch(dir) {
            case Direction.Down:
                staticInputY = -1;
                staticInputX = 0;
                break;
            case Direction.Up:
                staticInputY = 1;
                staticInputX = 0;
                break;
            case Direction.Right:
                staticInputY = 0;
                staticInputX = 1;
                break;
            case Direction.Left:
                staticInputY = 0;
                staticInputX = -1;
                break;
            case Direction.None:
                staticInputY = 0;
                staticInputX = 0;
                break;
        }
    }

    // ********************* Private Methods *************************** //

    private void OnAfterSceneLoad() {
        transform.position = SceneController.Instance.FindSpawnPosition(currentSpawnPointName);
    }

    private void PlayerTestInput() {
        if (Input.GetKeyDown(KeyCode.L)) {
            currentSpawnPointName = "Spawn1";
            SceneController.Instance.FadeAndLoadScene(SceneName.Scene001_Test.ToString());
        } else if (Input.GetKeyDown(KeyCode.T)) {
            currentSpawnPointName = "Spawn1";
            SceneController.Instance.DebugPassTime();
        }
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
