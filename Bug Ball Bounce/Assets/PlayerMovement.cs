using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float movementSpeed;
    public float jumpVelocity;
    public SpriteRenderer sr;
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

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            movementInput.y = jumpVelocity;
        }

        rb2d.velocity = movementInput;

        if (rb2d.velocity.x < 0) {
            sr.flipX = true;
        } else if (rb2d.velocity.x > 0) {
            sr.flipX = false;
        }
    }

    bool IsGrounded() {
        return Physics2D.Raycast(transform.position, -Vector2.up, 0.8f);
    }
}