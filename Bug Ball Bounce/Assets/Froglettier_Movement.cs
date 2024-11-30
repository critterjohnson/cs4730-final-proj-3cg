using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Froglettier_Movement : MonoBehaviour
{
    public float hopForce = 0.3f;
    public float hopInterval = 1.7f;
    public float detectionRange = 20f;

    private Transform player;
    private Rigidbody2D rb;

    
    //movement
    //uhhhhhhhh
    
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
                rb.AddForce(new Vector2(direction.x * hopForce, hopForce), ForceMode2D.Impulse);
                yield return new WaitForSeconds(hopInterval);
            }
            else
            {
                yield return null;
            }
        }
    }
}