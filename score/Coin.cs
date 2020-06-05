using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Variabila folosita pentru a da valoarea banutului colectat
    public int CoinValue;
    //Variabila pentru a ne asigura ca adunam o singura data fiecare banut de colectat
    public bool hasTouched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Daca banutul nu a fost atins
        if(hasTouched==false)
        {
            //Daca Player atinge banutul
            if(other.gameObject.CompareTag("Player"))
            {
                //Adunam valoarea banutului la scorul actual, distrugem banutul si il marcam ca atins
                ScoreManager.instance.ChangeScore(CoinValue);
                Destroy(gameObject);
                hasTouched = true;
            } 
        }
        
    }
}
