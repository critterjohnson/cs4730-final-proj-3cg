using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    private int bounceCount = 0; 
    public int maxBounces = 3; 
    public Transform holdPoint;      // A child of the player where the ball is "held"
    public BallControl bc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Bounce Count " + bounceCount);
        if (bounceCount > maxBounces) {
            Debug.Log("Destroying Ball");
            bc.setHolding(true);
            bounceCount = 0;
        } else {
            bounceCount += 1;
        }
    }
}
