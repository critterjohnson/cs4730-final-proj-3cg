using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float movementSpeed;
    private Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.y = rb2d.velocity.y;
        movementInput.x = Input.GetAxisRaw("Horizontal") * movementSpeed;

        rb2d.velocity = movementInput;
    }
}