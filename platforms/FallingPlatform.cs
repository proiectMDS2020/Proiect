using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
   Rigidbody2D rb2d;

    public float destroyDelay; //timpul in care va disparea placa


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {//daca player-ul a ajuns pe placa, aceasta  va fi distrusa;
           
            Destroy(gameObject, destroyDelay);
        }
    }

   

}
