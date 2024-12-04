using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawn : AttackChoice
{
    public GameObject flyPrefab;

    public override void Execute(Transform bossTransform, Transform playerTransform)
    {
        GameObject fly = Instantiate(flyPrefab, bossTransform.position, Quaternion.identity);
        
        SpriteRenderer flySprite = fly.GetComponent<SpriteRenderer>();
        SpriteRenderer bossSprite = bossTransform.GetComponent<SpriteRenderer>();

        if (flySprite != null && bossSprite != null)
        {
            flySprite.flipX = bossSprite.flipX;
        }
    }
}