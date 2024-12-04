using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // Assign in the Inspector or set dynamically.
    public float respawnDelay = 1f; // Delay before respawning.
    private Vector3 startPosition;

    void Start()
    {
        // Initialize the start position in case no respawn point is assigned.
        startPosition = transform.position;

        if (respawnPoint == null)
            respawnPoint = new GameObject("Default Respawn Point").transform;

        respawnPoint.position = startPosition;
    }

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
        transform.position = respawnPoint.position; // Move to respawn point.
        gameObject.SetActive(true); // Re-enable player.
    }
}
