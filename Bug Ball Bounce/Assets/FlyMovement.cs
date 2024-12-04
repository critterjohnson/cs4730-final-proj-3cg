using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float waveAmplitude = 1f;   
    public float waveFrequency = 7f;  
    public float flySpeed = 200f;
    public float lifetime = 20f;
    
    private float elapsedTime = 0f;
    private int moveDir = 1;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetMoveDirection(int direction)
    {
        moveDir = direction;
        spriteRenderer.flipX = moveDir == -1;
    }
    void Update()
    {

        float waveY = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;

        transform.position += new Vector3(-moveDir * flySpeed * Time.deltaTime, waveY * Time.deltaTime, 0);
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }
    
}