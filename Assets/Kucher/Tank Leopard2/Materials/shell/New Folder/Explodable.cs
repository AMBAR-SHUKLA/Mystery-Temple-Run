using UnityEngine;

public class Explodable : MonoBehaviour
{
    [Header("Explosion Settings")]
    public AudioClip explosionSound;
    public float destroyDelay = 5f;
    public float explosionVolume = 1f;  // 0 = silent, 1 = full volume

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f;
    }

    public void Explode()
    {
        if (explosionSound != null)
        {
            audioSource.clip = explosionSound;
            audioSource.volume = explosionVolume;  // Apply volume before playing
            audioSource.Play();
        }

        Destroy(gameObject, destroyDelay);
    }
}