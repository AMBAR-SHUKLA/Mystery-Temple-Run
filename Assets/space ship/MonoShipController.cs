using UnityEngine;

/// <summary>
/// Attach this script to the GameObject named "monoship" (tag: monoship).
/// The Player (tag: Player) lives inside the ship and is kept in place
/// by 4 invisible wall colliders that are children of this ship.
/// 
/// Movement:
///   - Ship moves: W/S (forward/back), A/D (left/right), Q/E (up/down)
///   - Ship rotates: Arrow Keys or Mouse (optional, toggle in Inspector)
///   - Player moves freely INSIDE the ship using standard WASD (handled separately)
/// </summary>
public class MonoShipController : MonoBehaviour
{
    [Header("Ship Movement Settings")]
    [Tooltip("How fast the ship translates through space")]
    public float shipMoveSpeed = 10f;

    [Tooltip("How fast the ship rotates")]
    public float shipRotateSpeed = 60f;

    [Header("Player Movement Settings")]
    [Tooltip("How fast the player moves inside the ship")]
    public float playerMoveSpeed = 5f;

    [Tooltip("How high the player can jump")]
    public float playerJumpForce = 5f;

    [Tooltip("Gravity applied to the player")]
    public float gravity = -9.81f;

    [Header("References (auto-found if left empty)")]
    public Transform playerTransform;

    // -- private --
    private CharacterController _playerCC;
    private Vector3 _playerVelocity;
    private bool _playerGrounded;

    // Ship's previous position/rotation used to drag the player along
    private Vector3 _prevShipPos;
    private Quaternion _prevShipRot;

    // ---------------------------------------------------------------
    void Start()
    {
        // Auto-find player if not assigned
        if (playerTransform == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                playerTransform = playerObj.transform;
            else
                Debug.LogError("[MonoShipController] No GameObject with tag 'Player' found!");
        }

        if (playerTransform != null)
            _playerCC = playerTransform.GetComponent<CharacterController>();

        // Snapshot starting state
        _prevShipPos = transform.position;
        _prevShipRot = transform.rotation;
    }

    // ---------------------------------------------------------------
    void Update()
    {
        MoveShip();
        MovePlayerInsideShip();
        CarryPlayerWithShip();

        // Update snapshots AFTER carrying player
        _prevShipPos = transform.position;
        _prevShipRot = transform.rotation;
    }

    // ---------------------------------------------------------------
    /// <summary>Move the whole ship in world space.</summary>
    void MoveShip()
    {
        // --- Translation ---
        float h = Input.GetAxis("Horizontal");   // A / D
        float v = Input.GetAxis("Vertical");     // W / S
        float upDown = 0f;
        if (Input.GetKey(KeyCode.E)) upDown = 1f;
        if (Input.GetKey(KeyCode.Q)) upDown = -1f;

        Vector3 moveDir = (transform.right * h) +
                          (transform.forward * v) +
                          (transform.up * upDown);

        transform.position += moveDir * shipMoveSpeed * Time.deltaTime;

        // --- Rotation (Arrow Keys) ---
        float yaw = 0f;
        float pitch = 0f;
        if (Input.GetKey(KeyCode.RightArrow)) yaw = 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) yaw = -1f;
        if (Input.GetKey(KeyCode.UpArrow)) pitch = -1f;
        if (Input.GetKey(KeyCode.DownArrow)) pitch = 1f;

        transform.Rotate(pitch * shipRotateSpeed * Time.deltaTime,
                         yaw * shipRotateSpeed * Time.deltaTime,
                         0f,
                         Space.Self);
    }

    // ---------------------------------------------------------------
    /// <summary>
    /// Move the player relative to the ship's local axes so it always
    /// feels like walking on the ship floor regardless of ship orientation.
    /// Uses CharacterController if available, otherwise raw Transform.
    /// </summary>
    void MovePlayerInsideShip()
    {
        if (playerTransform == null) return;

        // Player input axes (use separate keys to avoid conflict with ship)
        float px = 0f, pz = 0f;
        if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.L)) px = 1f;
        if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.J)) px = -1f;
        if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.I)) pz = 1f;
        if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.K)) pz = -1f;

        // Direction relative to ship orientation
        Vector3 moveLocal = (transform.right * px) +
                            (transform.forward * pz);

        if (_playerCC != null)
        {
            // --- CharacterController path ---
            _playerGrounded = _playerCC.isGrounded;
            if (_playerGrounded && _playerVelocity.y < 0f)
                _playerVelocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space) && _playerGrounded)
                _playerVelocity.y = Mathf.Sqrt(playerJumpForce * -2f * gravity);

            // Apply ship-relative gravity direction
            _playerVelocity += transform.up * gravity * Time.deltaTime;

            Vector3 totalMove = (moveLocal * playerMoveSpeed + _playerVelocity) * Time.deltaTime;
            _playerCC.Move(totalMove);
        }
        else
        {
            // --- Fallback: raw transform (no physics) ---
            playerTransform.position += moveLocal * playerMoveSpeed * Time.deltaTime;
        }
    }

    // ---------------------------------------------------------------
    /// <summary>
    /// When the ship moves or rotates, drag the player along so they
    /// stay in the same relative position inside the ship.
    /// This works even without making the player a child of the ship.
    /// </summary>
    void CarryPlayerWithShip()
    {
        if (playerTransform == null) return;

        // Delta position in world space
        Vector3 deltaPos = transform.position - _prevShipPos;

        // Delta rotation this frame
        Quaternion deltaRot = transform.rotation * Quaternion.Inverse(_prevShipRot);

        // Rotate the player's offset around the ship's new position
        Vector3 playerOffset = playerTransform.position - _prevShipPos;
        Vector3 rotatedOffset = deltaRot * playerOffset;

        Vector3 newPlayerPos = transform.position + rotatedOffset;

        if (_playerCC != null)
        {
            // Move via CharacterController so collisions still apply
            Vector3 carry = newPlayerPos - playerTransform.position;
            _playerCC.Move(carry);
        }
        else
        {
            playerTransform.position = newPlayerPos;
        }

        // Also rotate player to face same relative direction inside ship
        playerTransform.rotation = deltaRot * playerTransform.rotation;
    }
}