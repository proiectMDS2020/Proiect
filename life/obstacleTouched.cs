using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleTouched : MonoBehaviour
{
  
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            health.Health -= 1;
            deadPlayer.dead = true;
        }
    }
}
