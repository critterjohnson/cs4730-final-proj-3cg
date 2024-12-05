using System;
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
    public Animator animator;
    private Vector2 movementInput;
    private Boolean doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        doubleJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsGrounded());

        movementInput.y = rb2d.velocity.y;
        movementInput.x = Input.GetAxisRaw("Horizontal") * movementSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded() || doubleJump)) {
            movementInput.y = jumpVelocity;
            if (IsGrounded() == false) {
                doubleJump = false;
            }
        }

        rb2d.velocity = movementInput;

        if (rb2d.velocity.y > 0.001f) {
            animator.SetBool("IsJumping", true);
        } else {

            animator.SetBool("IsJumping", false);
        }

        if (rb2d.velocity.y < -0.001f) {
            animator.SetBool("IsFalling", true);
        } else {
            animator.SetBool("IsFalling", false);
        }

        if (Math.Abs(rb2d.velocity.x) > 0 && IsGrounded()) {
            animator.SetBool("IsMoving", true);
        } else {
            animator.SetBool("IsMoving", false);
        }

        if (rb2d.velocity.x < 0 && !sr.flipX) {
            sr.flipX = true;
        } else if (rb2d.velocity.x > 0 && sr.flipX) {
            sr.flipX = false;
        }

        if (IsGrounded())
        {
            doubleJump = true;
        }
    }

    public bool IsGrounded() {
        return Math.Abs(rb2d.velocity.y) < 0.01f;
    }
}