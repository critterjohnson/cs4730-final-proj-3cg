using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheapImitation : AttackChoice
{
    public float rollSpeed = 10f; // Speed at which the boss rolls towards the player
    public float rollDuration = 3f; // Duration of the roll attack
    public float rotationSpeed = 720f; // Speed at which the boss rotates during the roll

    private bool isRolling = false;
    private Vector2 direction;

    private SpriteRenderer spriteRenderer;
    private Transform bossTransform;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bossTransform = transform;
    }

    public override void Execute(Transform bossTransform, Transform playerTransform)
    {
        StartCoroutine(RollTowardsPlayer(bossTransform, playerTransform));
    }

    private IEnumerator RollTowardsPlayer(Transform bossTransform, Transform playerTransform)
    {
  
        direction = (playerTransform.position - bossTransform.position).normalized;
        
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;  // Flip the sprite to face left
        }
        else
        {
            spriteRenderer.flipX = false; // Flip the sprite to face right
        }
      
        isRolling = true;

        float elapsedTime = 0f;

        while (elapsedTime < rollDuration)
        {
    
            bossTransform.position += (Vector3)direction * rollSpeed * Time.deltaTime;

            float rotationStep = rotationSpeed * Time.deltaTime; // Degrees per second
            bossTransform.Rotate(0f, 0f, rotationStep);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        isRolling = false;
        
        bossTransform.rotation = Quaternion.identity;
        
    }
}