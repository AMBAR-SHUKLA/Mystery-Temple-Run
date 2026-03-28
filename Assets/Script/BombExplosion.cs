using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public float radius = 10f;
    public float force = 500f;
    public GameObject explosionEffect;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Spawn visual explosion effect
            if (explosionEffect != null)
                Instantiate(explosionEffect, transform.position, Quaternion.identity);

            // Apply explosion force to nearby rigidbodies
            Collider[] hits = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hit in hits)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(force, transform.position, radius);
            }

            // Destroy bomb
            Destroy(gameObject);
        }
    }
}

