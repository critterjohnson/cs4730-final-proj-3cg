using System;
using UnityEngine;
//made with assistamce from https://www.youtube.com/watch?v=fyaJQpBRk2U as a base
public class Durability : MonoBehaviour
{
    private int hitCount = 0;
    private int toDestroy = 2;
    private SpriteRenderer spriteRenderer;
    //private AudioSource _blockSound;
    
    private void Start() { spriteRenderer = GetComponent<SpriteRenderer>(); }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Ball")) return;
        //_blockSound.Play();
        hitCount++;
        float darkenFactor = 0.75f - 0.5f * hitCount / toDestroy;
        spriteRenderer.color = new Color(darkenFactor, darkenFactor, darkenFactor, 1f);

        if (hitCount >= toDestroy)
        {
            Destroy(gameObject);
        }
    }
}