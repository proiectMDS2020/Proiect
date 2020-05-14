using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadEnemie : MonoBehaviour
{
    public bool IsDead;

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.collider.name == "Player")
        {
            if (player.transform.position.y - transform.position.y >= 0.75)
            {
                animator.SetBool("IsDead", true);
                StartCoroutine(Destroy());
            }
            else
            {
                health.Health -= 1;
                deadPlayer.dead = true;
            }
               
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
    
}
