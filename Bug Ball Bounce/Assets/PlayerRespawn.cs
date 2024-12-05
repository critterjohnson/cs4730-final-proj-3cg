
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public float respawnDelay = 1f; // Delay before respawning.

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DieAndRespawn();
        }
    }

    void DieAndRespawn()
    {
        // Optionally disable player control or visuals temporarily.
        gameObject.SetActive(false);

        // Respawn after a delay.
        Invoke(nameof(Respawn), respawnDelay);
    }

    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameObject.SetActive(true); // Re-enable player.
    }
}