using UnityEngine;

/// <summary>
/// Attach this script to your Player GameObject.
/// It controls Walk / Idle animation based on movement keys.
///
/// SETUP REQUIRED:
///   1. Your Player must have an Animator component.
///   2. Animator Controller must have:
///        - An Idle state (default/orange state)
///        - A Walk state
///        - A Bool parameter named exactly: isWalking
///        - Transitions between Idle <-> Walk based on isWalking
/// </summary>
public class PlayerAnimationController : MonoBehaviour
{
    [Header("Animation Parameter Name")]
    [Tooltip("Must exactly match the Bool parameter name in your Animator Controller")]
    public string walkingParam = "isWalking";

    // Keys that count as "moving the player" - matches your ship script (I/K/J/L)
    private readonly KeyCode[] _moveKeys = new KeyCode[]
    {
        KeyCode.I,          // forward
        KeyCode.K,          // backward
        KeyCode.J,          // left
        KeyCode.L,          // right
        KeyCode.Keypad8,    // forward (numpad)
        KeyCode.Keypad2,    // backward (numpad)
        KeyCode.Keypad4,    // left (numpad)
        KeyCode.Keypad6,    // right (numpad)
    };

    private Animator _animator;

    // ---------------------------------------------------------------
    void Start()
    {
        _animator = GetComponent<Animator>();

        if (_animator == null)
            Debug.LogError("[PlayerAnimationController] No Animator component found on " + gameObject.name + "!");
    }

    // ---------------------------------------------------------------
    void Update()
    {
        if (_animator == null) return;

        bool isMoving = IsAnyMoveKeyHeld();

        // Set the Bool parameter — Animator handles the transition automatically
        _animator.SetBool(walkingParam, isMoving);
    }

    // ---------------------------------------------------------------
    /// <summary>Returns true if any movement key is currently held down.</summary>
    bool IsAnyMoveKeyHeld()
    {
        foreach (KeyCode key in _moveKeys)
        {
            if (Input.GetKey(key))
                return true;
        }
        return false;
    }
}
