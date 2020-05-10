using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    GroundCheck myGround;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = true;
    bool doubleJump = true;

    private void Start()
    {
        myGround = this.GetComponentInChildren<GroundCheck>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(jump);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false); 
    }

    void FixedUpdate()
    {
        //Move our caracter
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}