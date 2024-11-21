using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float launchForce = 10f;
    public GameObject ball;          // The ball GameObject
    public Transform holdPoint;      // A child of the player where the ball is "held"
    public SpriteRenderer sr;

    private bool isHolding = true;   // Whether the player is holding the ball

    public Rigidbody2D PlayerRB;
    
    public CircleCollider2D ballCollider; 

    void Update()
    {
        if (!sr.isVisible) {
            setHolding(true);
        }

        if (isHolding)
        {
            // Keep the ball at the hold point
            ball.transform.position = holdPoint.position;

            // Check for throw input
            if (Input.GetKeyDown(KeyCode.E))
            {
                ThrowBall();
            }
        }
    }

    public void setHolding(bool h) {
        isHolding = h;
        ballCollider.enabled = !h;
    }

    void ThrowBall()
    {
        // Release the ball
        setHolding(false);

        // Detach the ball from the player
        ball.transform.parent = null;

        // Enable physics on the ball
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = Vector2.zero;
            float angle = PlayerRB.velocity.x < 0 ? 135f : 45f; // Change this to your desired angle
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;

            // Apply force upwards
            rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
        }
    }
}
