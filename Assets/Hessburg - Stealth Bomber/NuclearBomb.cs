using UnityEngine;

public class NuclearBomb : MonoBehaviour
{
    [Header("Explosion Settings")]
    public float radius = 50f;                 // How far objects are affected
    public float force = 2000f;                // Strength of explosion
    public GameObject explosionEffect;         // Particle prefab
    public float upwardsModifier = 10f;        // Lifts objects for shockwave effect

    [Header("Camera Shake")]
    public Camera mainCamera;
    public float shakeDuration = 1f;
    public float shakeMagnitude = 2f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Explode();
        }
    }

    void Explode()
    {
        // 1. Spawn visual effect
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // 2. Apply explosion force to nearby rigidbodies
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(force, transform.position, radius, upwardsModifier, ForceMode.Impulse);
        }

        // 3. Camera shake
        if (mainCamera != null)
            StartCoroutine(ShakeCamera());

        // 4. Destroy the bomb
        Destroy(gameObject);
    }

    // Simple camera shake coroutine
    System.Collections.IEnumerator ShakeCamera()
    {
        Vector3 originalPos = mainCamera.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            mainCamera.transform.localPosition = originalPos + randomOffset;
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.localPosition = originalPos;
    }
}
