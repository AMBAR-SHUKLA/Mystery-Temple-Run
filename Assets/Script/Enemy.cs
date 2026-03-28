using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyFollowDestroyPlayer : MonoBehaviour
{
    public Transform player;
    public float baseSpeed = 4f;
    public float speedIncreaseRate = 0.1f;

    private Rigidbody rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevent tipping
        currentSpeed = baseSpeed;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Increase enemy speed over time
        currentSpeed += speedIncreaseRate * Time.fixedDeltaTime;

        // Move enemy toward player using Rigidbody
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 move = direction * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if enemy touches the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destroy the player
            Debug.Log("Game Over! Player Destroyed");

            // Optionally, you can do other game over logic here
            // e.g., show UI, stop enemy movement, etc.
        }
    }
}

