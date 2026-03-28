using UnityEngine;

public class ShipControlStation : MonoBehaviour
{
    public bool playerInControlZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerInControlZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInControlZone = false;
    }
}