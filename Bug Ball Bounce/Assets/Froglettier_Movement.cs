using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Froglettier_Movement : MonoBehaviour
{
    public float hopForce = 0.5f;
    public float hopInterval = 1.7f;
    public float detectionRange = 5f;

    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private bool charging = false;

    
    //movement
    //uhhhhhhhh
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        StartCoroutine(Hop());
    }

    void Update() {
        if (rb.velocity.y > 0.01f) {
            animator.SetBool("IsRising", true);
        } else {
            animator.SetBool("IsRising", false);
        }

        if (rb.velocity.y < -0.001f) {
            animator.SetBool("IsFalling", true);
        } else {
            animator.SetBool("IsFalling", false);
        }

        Debug.Log(animator.GetBool("IsRising"));
    }

    private IEnumerator Hop()
    {
        while (true)
        {
            if (!charging)
            {
                if (player != null && Vector2.Distance(transform.position, player.position) <= detectionRange)
                {
                    yield return StartCoroutine(ChargeAttack());
                }
                else
                {
                    Vector2 direction = (player.position - transform.position).normalized;
                    rb.AddForce(new Vector2(direction.x * hopForce, hopForce), ForceMode2D.Impulse);
                    yield return new WaitForSeconds(hopInterval);
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator ChargeAttack()
    {
        charging = true;
        animator.SetBool("IsCharging", true);

        yield return new WaitForSeconds(0.6f);

        if (player != null)
        {
            // Calculate charge direction
            Vector2 direction = (player.position - transform.position).normalized;
            animator.SetBool("IsCharging", false);
            rb.AddForce(new Vector2(direction.x * 7f, 7f), ForceMode2D.Impulse);
        }


        // Wait for the charge to finish
        yield return new WaitForSeconds(1f); // Adjust this time based on how long the charge should last

        charging = false;
    }
}