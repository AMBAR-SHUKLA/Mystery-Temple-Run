using UnityEngine;

public class JetSimpleController : MonoBehaviour
{
    [Header("Flight Settings")]
    public float forwardSpeed = 50f;    // Constant forward speed
    public float rotationSpeed = 80f;   // Rotation speed in degrees/sec

    [Header("Bomb Settings")]
    public GameObject bombPrefab;
    public Transform bombPoint;
    public float bombForwardSpeed = 20f; // Initial bomb speed

    [Header("Collision Settings")]
    public GameObject explosionPrefab;
    public string groundTag = "Ground";

    void Update()
    {
        MoveForward();
        HandleRotation();
        HandleBombDrop();
    }

    // Move forward constantly
    void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    // Rotate up/down and left/right
    void HandleRotation()
    {
        float yaw = 0f;
        float pitch = 0f;

        // Left/Right
        if (Input.GetKey(KeyCode.A)) yaw = -1f;
        if (Input.GetKey(KeyCode.D)) yaw = 1f;

        // Up/Down
        if (Input.GetKey(KeyCode.UpArrow)) pitch = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) pitch = -1f;

        transform.Rotate(Vector3.up * yaw * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * pitch * rotationSpeed * Time.deltaTime);
    }

    // Bomb drop
    void HandleBombDrop()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombPrefab != null && bombPoint != null)
        {
            GameObject bomb = Instantiate(bombPrefab, bombPoint.position, transform.rotation);
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            if (rb != null)
                rb.linearVelocity = transform.forward * bombForwardSpeed; // Give initial forward velocity
        }
    }

    // Collision with ground
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(groundTag))
        {
            if (explosionPrefab != null)
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}

