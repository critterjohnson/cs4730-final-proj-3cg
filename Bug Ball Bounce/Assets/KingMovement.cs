using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovement : MonoBehaviour
{
    public float hopForce = 7f;     
    public float hopInterval = 3f;   
    public int hopsPerCycle = 3;        
    public float idleTime = 2f;
    

    private Transform player;    
    private Rigidbody2D rb;         
    private SpriteRenderer spriteRenderer; 
    private bool isHopping = false;  
    private AttackChoice[] attacks;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attacks = GetComponents<AttackChoice>();
      
        StartCoroutine(BossBehaviorCycle());
    }

    private IEnumerator BossBehaviorCycle()
    {
        while (true)
        {
            // Idle Phase
            yield return Idle();

            // Hopping Phase
            if (attacks.Length > 0 && Random.value > 0.25f)
            {
                yield return ExecuteRandomAttack();
            }
            else
            {
                yield return HopTowardsPlayer();
            }
        }
    }

    private IEnumerator Idle()
    {
        isHopping = false;
        yield return new WaitForSeconds(idleTime);
    }

    private IEnumerator HopTowardsPlayer()
    {
        isHopping = true;

        for (int i = 0; i < hopsPerCycle; i++)
        {
         
            if (player != null)
            {
              
                Vector2 direction = (player.position - transform.position).normalized;

           
                if (direction.x > 0)
                {
                    spriteRenderer.flipX = true; // Facing right
                }
                else
                {
                    spriteRenderer.flipX = false;  // Facing left
                }
                
                rb.AddForce(new Vector2(direction.x * hopForce, hopForce), ForceMode2D.Impulse);
            }
            
            yield return new WaitForSeconds(hopInterval);
        }

        isHopping = false;
        yield return null;
    }
    private void FixedUpdate()
    {
        if (!isHopping)
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Stop horizontal movement
        }
    }
    private IEnumerator ExecuteRandomAttack()
    {
        // Choose a random attack and execute it
        int randomIndex = Random.Range(0, attacks.Length);
        attacks[randomIndex].Execute(transform, player);

        // Add a delay for the attack duration
        yield return new WaitForSeconds(idleTime);
    }
}