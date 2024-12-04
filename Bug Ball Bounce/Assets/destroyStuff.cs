using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyStuff : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject); // Destroy this tadpole enemy
        }
    }
}