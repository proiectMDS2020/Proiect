using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
  
    Rigidbody2D rb2d;
    public float fallDelay;//in cat timp va disparea placa
    public static bool disabled = false;// variabila utilizata pentru a seta placa activa sau inactiva

    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
    }
     
    void Update()
    {
        //setam placa activa sau inactiva in functie de valoare variabilei disabled
        if(disabled)
        {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);
        }
     }

    void OnCollisionEnter2D (Collision2D col)
    {
        //la coleziunea cu player-ul, placa va apela functia "Fall"
        if (col.gameObject.tag.Equals("Player"))
        { 
           StartCoroutine(Fall());
        }
    }
    
    IEnumerator Fall()
    {
        //placa asteapta numarul de secunde reprezentat de variabila "fallDelay"
         yield return new WaitForSeconds(fallDelay);
         disabled = true; //seteaza obiectul ca fiind inactiv, facand variabila disabled true;
         yield return 0;
    }
}
