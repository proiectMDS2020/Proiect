using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    GroundCheck myGround;
    public bool doubleJump;

    // Start is called before the first frame update
    private void Start()
    {
        myGround = this.GetComponentInChildren<GroundCheck>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(4, rb.velocity.y);
            if (myGround.isGrounded)
            {
                animator.Play("Run");
            }
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-4, rb.velocity.y);
            if (myGround.isGrounded)
            {
                animator.Play("Run");
            }
            spriteRenderer.flipX = true;
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (myGround.isGrounded)
            {
                animator.Play("Idle");
            }
        }

    }
    private void Update()
    {
        if (myGround.isGrounded == true)
        {
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (myGround.isGrounded == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, 12);
                animator.Play("Jump");
            }
            else
            {
                if (doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 15);
                    animator.Play("Jump");
                    doubleJump = false;
                }
            }
        }
    }

}

    
