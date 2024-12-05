using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawn : AttackChoice
{
    public GameObject flyPrefab;

    public override void Execute(Transform bossTransform, Transform playerTransform)
    {
        GameObject fly = Instantiate(flyPrefab, bossTransform.position, Quaternion.identity);
        
        SpriteRenderer bossSprite = bossTransform.GetComponent<SpriteRenderer>();
        FlyMovement flyMovement = fly.GetComponent<FlyMovement>();

        if (bossSprite != null && flyMovement != null)
        {
            // Determine the fly's movement direction based on the boss's flipX state
            int moveDirection = bossSprite.flipX ? -1 : 1; // 1 = right, -1 = left

            // Set the fly's movement direction
            flyMovement.SetMoveDirection(moveDirection);
        }
    }
}