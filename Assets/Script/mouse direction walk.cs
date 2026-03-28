using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouseControl : MonoBehaviour
{
    [Header("Forward Movement")]
    public float forwardSpeed = 5f;
    public float speedIncreaseRate = 0.2f;

    [Header("Side Movement")]
    public float sideSpeed = 4f;
    public float maxSideLimit = 3f; // limits movement on X axis

    [Header("Jump")]
    public float jumpForce = 6f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // freeze rotation
    }

    void Update()
    {
        // Increase forward speed over time
        forwardSpeed += speedIncreaseRate * Time.deltaTime;

        // --- Mouse Position in World ---
        Vector3 targetPos = transform.position;

        if (Mouse.current != null && Camera.main != null)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();

            // Create a ray from camera through mouse position
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            // Plane at player's height (XZ plane)
            Plane plane = new Plane(Vector3.up, transform.position);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 worldMousePos = ray.GetPoint(distance);
                targetPos.x = Mathf.Clamp(worldMousePos.x, -maxSideLimit, maxSideLimit);
                // targetPos.z = Mathf.Clamp(worldMousePos.z, transform.position.z, transform.position.z + 10f); // optional
            }
        }

        // --- Smooth horizontal movement toward mouse ---
        float newX = Mathf.MoveTowards(transform.position.x, targetPos.x, sideSpeed * Time.deltaTime);

        // --- Jump ---
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // --- Set Rigidbody velocity ---
        Vector3 vel = rb.linearVelocity;
        vel.x = (newX - transform.position.x) / Time.deltaTime; // calculate X velocity
        vel.y = rb.linearVelocity.y; // keep Y velocity for jump/fall
        vel.z = forwardSpeed;   // auto-run forward
        rb.linearVelocity = vel;
    }

    void FixedUpdate()
    {
        // Ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }
}
