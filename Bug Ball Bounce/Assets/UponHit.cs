using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UponHit : MonoBehaviour
{
    // Start is called before the first frame update
    public float knockbackForce = 20f; // Adjust to control how far the player flies back
    public float knockbackDuration = 0.2f; // Duration of knockback
    private Rigidbody2D rb;
    private bool isKnockedBack = false; // Prevent movement during knockback

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Calculate knockback direction
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

            // Apply knockback force
            StartCoroutine(ApplyKnockback(knockbackDirection));
        }
    }

    private IEnumerator ApplyKnockback(Vector2 direction)
    {
        isKnockedBack = true;

        // Apply impulse force in the knockback direction
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        // Wait for the knockback duration
        yield return new WaitForSeconds(knockbackDuration);

        // End knockback
        isKnockedBack = false;
    }

    void Update()
    {
        // Example: Disable player controls during knockback (optional)
        if (isKnockedBack)
        {
            return; // Prevent further movement inputs
        }

        // Player movement logic here (e.g., horizontal movement, jumping)
    }
}