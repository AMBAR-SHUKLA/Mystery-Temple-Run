using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float gravityStrength = 10f; // How strong the pull is
    public float eventHorizon = 1f;     // Distance at which object is destroyed

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = transform.position - other.transform.position;
            float distance = direction.magnitude;

            // Apply pull force
            rb.AddForce(direction.normalized * gravityStrength / Mathf.Max(distance, 0.1f));

            // Destroy object if too close (event horizon)
            if (distance < eventHorizon)
            {
                Destroy(other.gameObject);
            }
        }
    }
}