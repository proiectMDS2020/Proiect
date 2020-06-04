using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class enemiesMoving : MonoBehaviour
{
    // viteza cu care se misca inamicul
    public float speed;

    // variabila cu care stim cand mergem la dreapta
    public bool moveRight;

    // variabila cu care stim cand urcam
    public bool moveUp;

    // caz particular: un inamic sta pe loc -> setam variabila de mai jos la true
    public bool playIdle;

    // animatorul inamicului -> activam/dezactivam diferite animatii
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // daca e true -> activam animatia corespunzatoare
        if (playIdle)
        {
            animator.SetBool("playIdle", true);
        }
        else
        {
            // daca inamicul are acest tag, inseamna ca ne miscam sus-jos
            if (gameObject.CompareTag("upDown"))
            {
                if (moveUp)
                {
                    // daca ne miscam in sus, pe X avem 0 -> directia este pe Y
                    transform.Translate(0, Time.deltaTime * speed, 0);

                    // de asemenea, mentinem dimensiunea la cea stabilita
                    // ambele valori pozitive -> nu schimbam directia inamicului
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    // daca ne miscam in jos, pe X avem 0 -> directie pe Y (valoare negativa)
                    transform.Translate(0, -Time.deltaTime * speed, 0);

                    // de asemenea, mentinem dimensiunea la cea stabilita
                    // ambele valori pozitive -> nu schimbam directia inamicului
                    transform.localScale = new Vector2(1, 1);
                    transform.localScale = new Vector2(1, 1);
                }
            }
            // inamicul nu are tagul "upDown" -> merge stanga-dreapta
            else
            {
                if (moveRight)
                {
                    // caz particular cu tagul "superPiggy": dorim sa avem inamicii de dimensiuni mai mari -> folosim acest tag
                    // mergem la dreapta
                    transform.Translate(Time.deltaTime * speed, 0, 0);
                    if (gameObject.CompareTag("superPiggy"))
                    {
                        // facem flip la inamic(ii schimbam directia la 180 de grade)
                        transform.localScale = new Vector2(-2, 2);
                    }
                    else
                    {
                        // facem flip la inamic(ii schimbam directia la 180 de grade)
                        transform.localScale = new Vector2(-1, 1);
                    }
                }
                else
                {
                    // mergem la stanga si facem flip la inamic (ii schimbam directia la 180 de grade)
                    // si aici cazul cu "superPiggy"
                    transform.Translate(-Time.deltaTime * speed, 0, 0);
                    if (gameObject.CompareTag("superPiggy"))
                    {
                        transform.localScale = new Vector2(2, 2);
                    }
                    else
                    {
                        transform.localScale = new Vector2(1, 1);
                    }
                }
            }
        }
    }

    // daca ne lovim de obiectele delimitatoare schimbam valoarea variabilelor pentru schimbarea directiei
    void OnTriggerEnter2D(Collider2D trigg)
    {
        // tagul "turn" este folosit pentru delimitarile in cazul in care miscarea este stanga-dreapta
        if (trigg.gameObject.CompareTag("turn"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
        // miscarea este sus-jos
        else
        {
            if (moveUp)
            {
                moveUp = false;
            }
            else
            {
                moveUp = true;
            }
        }
    }
}
