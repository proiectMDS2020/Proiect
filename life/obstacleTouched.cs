using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleTouched : MonoBehaviour
{
    public bool sentInfo;

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
                // scadem numarul de vieti si activam animatia de hit/lose/die
                health.Health -= 1;
                deadPlayer.dead = true;
                hasDied = true;
            }
        }

    }
}
