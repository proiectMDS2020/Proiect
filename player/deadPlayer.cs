using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class deadPlayer : MonoBehaviour
{
    // variabila folosita in celelalte script-uri pentru a sti cand player-ul moare
    public static bool dead;

    // obiectul de repozitionare a player-ului
    [SerializeField] Transform SpawnPoint;

    // activam/dezactivam animatii
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);

        // daca a murit
        if (dead)
        {
            dead = false;

            // activam animatia de hit/lose/die
            animator.SetBool("IsDead", true);

            // dam restart la nivel
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1);
        // repozitionam personajul la inceputul nivelului
        transform.position = SpawnPoint.position;

        // setam toate varibilele la false pentru reinceperea jocului
        obstacleTouched.hasDied = false;
        fallingScript.hasDied = false;
        deadEnemie.hasDied = false;
        animator.SetBool("IsDead", false);
    }

}
