using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.EditorTools;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float launchForce = 10f;
    public GameObject BallPrefab;          // The ball prefab GameObject
    public Transform holdPoint;      // A child of the player where the ball is "held"

    public SpriteRenderer PlayerSR;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb2d;
    
    public CircleCollider2D ballCollider; 
    public float ScaleInc;
    public float ScaleMin;
    public float ScaleMax;
    public float MassInc;

    private GameObject holdingBall;


    void Update()
    {
        // start roll
        if (Input.GetKeyDown(KeyCode.E)) {
            holdingBall = Instantiate(BallPrefab, gameObject.transform.position, Quaternion.identity);
            holdingBall.transform.localScale = new Vector3(ScaleMin, ScaleMin, ScaleMin);
            
            holdingBall.GetComponent<Collider2D>().enabled = false;
        }

        if (holdingBall != null) {
            // set the ball's position so the bottom touches the ground no matter what size
            // this can be optimized - don't need to get the ball component on every frame
            SpriteRenderer ballSR = holdingBall.GetComponent<SpriteRenderer>();
            Vector3 ballSize = ballSR.bounds.size;
            Vector3 playerSize = PlayerSR.bounds.size;

            Vector2 newPos = new Vector2(
                gameObject.transform.position.x + 0.5f*playerSize.x + 0.5f*ballSize.x,
                gameObject.transform.position.y - 0.4f*playerSize.y + 0.5f*ballSize.y
            );
            if (PlayerSR.flipX) {
                newPos.x = gameObject.transform.position.x - 0.5f*playerSize.x - 0.5f*ballSize.x;
            }
            holdingBall.transform.position = newPos;

            if (holdingBall.transform.localScale.x < ScaleMax && rb2d.velocity.x != 0 && playerMovement.IsGrounded()) {
                holdingBall.transform.localScale += new Vector3(ScaleInc, ScaleInc, ScaleInc);
                rb2d.mass += MassInc;
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        holdingBall.GetComponent<Collider2D>().enabled = true;

        // Enable physics on the ball
        Rigidbody2D rb = holdingBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = Vector2.zero;
            float angle = PlayerSR.flipX ? 135f : 45f; // Change this to your desired angle
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;

            // Apply force upwards
            rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
        }

        holdingBall = null;
    }
}
