using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; // referinta catre codul CharacterController2D care efectueaza in fapt miscarea
    public Animator animator; // referinta catre animatiile jucatorului

    public float runSpeed = 40f; // viteza cu care se misca jucatorul

    float horizontalMove = 0f; // directia in care se misca juctaorul

    bool jump = false; // determina daca juctaorul solicita sa sara

    // Update is called once per frame
    void Update()
    {
        // jucatorul doreste sa se miste in directia desemnata de GetAxisRow
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        // se activeaza animatia de alergare
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // jucatorul doreste sa sara
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            // se activeaza animatia de sarit
            animator.SetBool("IsJumping", true);
        }
    }

    // functie pentru aterizarea juctaorului
    public void OnLanding()
    {
        // se dezactiveaza animatia de sarit
        animator.SetBool("IsJumping", false);
    }
    

    void FixedUpdate()
    {
        // apelarea functiei care controleaza miscarile jucatorului din CharacterController2D
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // daca jucatorul se afla pe o platforma miscatoare se va misca impreuna cu ea
        if (col.gameObject.name.Equals("MovingPlatform"))
            this.transform.parent = col.transform;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("MovingPlatform"))
            this.transform.parent = null;
    }
}
