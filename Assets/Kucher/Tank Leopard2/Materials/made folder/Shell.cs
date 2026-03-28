using UnityEngine;

public class Shell : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f; // Auto-destroy after 5 seconds

    void Start()
    {
        // Move forward when spawned
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;

        // Destroy shell after lifetime
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Optional: destroy on impact
        Debug.Log("Shell hit: " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
