using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadEnemies : MonoBehaviour
{
    // variabila folosita pentru activarea/dezactivarea animatiei de hit
    public bool IsDead;

    // variabila folosita pentru ca player-ul sa moara o singura data
    public static bool hasDied = false;

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D player)
    {
        // daca atinge player
        if (player.collider.name == "Player")
        {
            // daca distanta dintre pozitia pe axa oY a pleyer-ului si 
            // a inamicului este >= jumatate din inaltimea player-ului (in cazul nostru 1.5 / 2) -> am omorat inamicul
            if (player.transform.position.y - transform.position.y >= 0.75)
            {
                animator.SetBool("IsDead", true);

                // distrugem obiectul
                StartCoroutine(Destroy());
            }
            else
            {
                // altfel, moare player-ul
                if (!hasDied)
                {
                    // scadem numarul de vieti
                    health.Health -= 1;

                    // activam animatia de hit
                    deadPlayer.dead = true;
                    hasDied = true;
                }

            }

        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }

}
