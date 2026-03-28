using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load scenes

public class SceneTrigger : MonoBehaviour
{
    // Name of the scene to load
    public string sceneToLoad;

    // Detect trigger collision
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object touching is the player
        if (other.CompareTag("Player"))
        {
            // Load the new scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

