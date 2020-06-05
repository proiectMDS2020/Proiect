using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraLife : MonoBehaviour
{
    //Variabila pentru a ne asigura ca adunam o singura data fiecare trifoi de colectat pentru viata extra
    public bool hasTouched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Daca nu a fost atins
        if (hasTouched == false)
        {
            //Daca este atins de Player
            if (other.gameObject.CompareTag("Player"))
            {
                //Creste numarul de vieti, este distrus trifoiul si este marcat ca atins
                health.Health += 1;
                Destroy(gameObject);
                hasTouched = true;
            }
        }

    }
}
