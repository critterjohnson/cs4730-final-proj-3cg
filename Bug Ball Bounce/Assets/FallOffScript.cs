using UnityEngine;
using UnityEngine.SceneManagement;


public class FallOff : MonoBehaviour
{
    public float fallThreshold = -50f; // Y position threshold for falling

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
