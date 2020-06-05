using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapolineScript : MonoBehaviour
{
    bool onTop; //variabila utilizata pentru a vedea daca player-ul se afla sau nu deasupra trambulinei;

    GameObject bouncer; //player-ul

    Animator anim; //animatia trambulinei

    public Vector2 velocity; //utilizat pentru a seta cat de tare va fi aruncat in aer player-ul;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    


    void OnCollisionStay2D(Collision2D other)
    {
        //atunci cand player-ul se afla deasupra trambulinei, setam animatia true 
        if (onTop)
        {
            anim.SetBool("isStepped", true);

            bouncer = other.gameObject;//setam player-ul (obiectul care va fi aruncat)

        }

    }
     void OnTriggerEnter2D()
    {
        //daca player-ul ajunge deasupra trambulinei, setam variabila onTop = true;
        onTop = true;
    }


    void OnTriggerExit2D()
    { 
        //cand player-ul iese de pe trambulina, oprim animatia trambulinei, setam variabila onTop ='false';
        onTop = false;
        anim.SetBool("isStepped", false);
    }

    void Jump()
    {   //aplicatie utilizata pentru a arunca in aer player-ul;
        bouncer.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
