using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    private int bounceCount = 0; 
    public int maxBounces = 3; 
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        bounceCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!sr.isVisible) {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Bounce Count " + bounceCount);
        if (bounceCount > maxBounces) {
            Debug.Log("Destroying Ball");
            Destroy(gameObject);
            bounceCount = 0;
        } else {
            bounceCount += 1;
        }
    }
}
