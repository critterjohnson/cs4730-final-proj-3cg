using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashOut : AttackChoice
{
    public float jumpHeight = 5f;  // The height of the jump
    public float jumpSpeed = 2f;   // The speed of the jump (how fast it takes to reach the highest point)
    public float attackDuration = 3f; // The total duration of the attack (jump + fall)

    private Transform bossTransform;
    private Vector2 startPos;
    private Vector2 targetPos;

    void Awake()
    {
        bossTransform = transform;
    }

    public override void Execute(Transform bossTransform, Transform playerTransform)
    {
        StartCoroutine(JumpAbovePlayer(bossTransform, playerTransform));
    }

    private IEnumerator JumpAbovePlayer(Transform bossTransform, Transform playerTransform)
    {
        startPos = bossTransform.position;

        // Determine the target position (directly above the player in X, Y)
        targetPos = new Vector2(playerTransform.position.x, playerTransform.position.y + jumpHeight);

        float timeElapsed = 0f;

        // Simulate the parabolic jump
        while (timeElapsed < attackDuration)
        {
            timeElapsed += Time.deltaTime;
            float normalizedTime = timeElapsed / attackDuration;
            float height = 4 * jumpHeight * normalizedTime * (1 - normalizedTime);
            float xPos = Mathf.Lerp(startPos.x, targetPos.x, normalizedTime);
            float yPos = Mathf.Lerp(startPos.y, targetPos.y, normalizedTime) + height;
            bossTransform.position = new Vector2(xPos, yPos);

            yield return null;
        }
        Debug.Log("JumpAttack Finished");
      
    }
}