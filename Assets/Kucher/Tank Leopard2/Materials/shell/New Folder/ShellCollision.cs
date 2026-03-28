using UnityEngine;

public class ShellCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Notify the hit object to explode
        Explodable explodable = collision.gameObject.GetComponent<Explodable>();
        if (explodable != null)
        {
            explodable.Explode();
        }

        // Destroy the shell itself
        Destroy(gameObject);
    }
}