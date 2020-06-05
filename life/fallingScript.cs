using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingScript : MonoBehaviour
{
    // obiect folosit pentru repozitionarea player-ului la inceputul nivelului
    // daca numarul de vieti este > 0
    public GameObject spawn;

    // variabila folosita pentru ca player-ul sa moara o singura data
    public static bool hasDied = false;


    void OnCollisionEnter2D(Collision2D col)
    {
        // daca player-ul n-a murit
        if (!hasDied)
        {
            // daca am lovit player-ul
            if (col.transform.CompareTag("Player"))
            {
                // scad numarul de vieti si repozitionez personajul la inceput
                health.Health -= 1;
                hasDied = true;
                deadPlayer.dead = true;
            }
        }
    }
}
