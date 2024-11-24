using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float launchForce = 10f;
    public GameObject BallPrefab;          // The ball prefab GameObject
    public Transform holdPoint;      // A child of the player where the ball is "held"

    public SpriteRenderer PlayerSR;
    
    public CircleCollider2D ballCollider; 
    public float ScaleInc;
    public float ScaleMin;
    public float ScaleMax;

    private GameObject holdingBall;


    void Update()
    {
        // if (PlayerSR.flipX) {
        //     holdPoint.transform.position = gameObject.transform.position;
        // }

        // start roll
        if (Input.GetKeyDown(KeyCode.E)) {
            holdingBall = Instantiate(BallPrefab, holdPoint.transform.position, Quaternion.identity);
            holdingBall.transform.localScale = new Vector3(ScaleMin, ScaleMin, ScaleMin);
        }

        if (holdingBall != null) {
            holdingBall.transform.position = holdPoint.transform.position;

            if (holdingBall.transform.localScale.x < ScaleMax) {
                holdingBall.transform.localScale += new Vector3(ScaleInc, ScaleInc, ScaleInc);
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
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
