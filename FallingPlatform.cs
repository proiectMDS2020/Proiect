using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
   Rigidbody2D rb2d;

    public float fallDelay;
    public float destroyDelay;
 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Invoke("DropPlatform", fallDelay);
            Destroy(gameObject, destroyDelay);
        }
    }
    
   void DropPlatform()
    {
        rb2d.isKinematic = false;
    }
  
}
