using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TadpoliceMovement : MonoBehaviour
{
    public float hopForce = 0.2f;
    public float hopInterval = 2.5f;
    public float detectionRange = 15f;

    private Transform player;
    private Rigidbody2D rb;
    private bool isFacingLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(HopTowardsPlayer());
    }

    private IEnumerator HopTowardsPlayer()
    {
        while (true)
        {
            if (player != null && Vector2.Distance(transform.position, player.position) <= detectionRange)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                if ((direction.x > 0 && !isFacingLeft) || (direction.x < 0 && isFacingLeft))
                {
                    FlipSprite();
                }
                rb.AddForce(new Vector2(direction.x * hopForce, hopForce), ForceMode2D.Impulse);
                yield return new WaitForSeconds(hopInterval);
            }
            else
            {
                yield return null;
            }
        }
    }
    private void FlipSprite()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip the x-scale
        transform.localScale = localScale;
    }
}
