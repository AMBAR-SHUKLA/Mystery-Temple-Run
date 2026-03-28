using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAutoRun : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float speedIncreaseRate = 0.2f;

    [Header("Jump")]
    public float jumpForce = 6f;

    [Header("Mouse")]
    public float mouseSensitivity = 3f;

    private Rigidbody rb;
    private float rotationY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Increase speed over time
        moveSpeed += speedIncreaseRate * Time.deltaTime;

        // Mouse controls direction
        if (Mouse.current != null)
        {
            float mouseX = Mouse.current.delta.ReadValue().x;
            rotationY += mouseX * mouseSensitivity;
            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }

        // Jump anytime
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Move FORWARD in the direction player is facing
        Vector3 forwardMove = transform.forward * moveSpeed;
        rb.linearVelocity = new Vector3(
            forwardMove.x,
            rb.linearVelocity.y,
            forwardMove.z
        );
    }
}



