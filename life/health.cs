using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    // numarul de vieti ale jucatorului (minim 0, maxim 5) 
    public static int Health;

    // vector de animators, punul pentru fiecare inima din health bar
    public Animator[] animator;

    // vector pentru inimi propriu-zise
    public GameObject[] hearts;


    // Start is called before the first frame update
    void Start()
    {
        // daca pui mai intai scena de lose, apoi de win (win e ultima), pune mai jos -1 
        // index = SceneManager.sceneCount();

        // setam valoarea initiala la 3
        Health = 3;

        // afisam doar primele 3 inimi
        hearts[0].gameObject.SetActive(true);
        hearts[1].gameObject.SetActive(true);
        hearts[2].gameObject.SetActive(true);
        hearts[3].gameObject.SetActive(false);
        hearts[4].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // avem grija sa nu depasim niciodata numarul de 5 inimi
        if (Health > 5)
        {
            Health = 5;
        }

        // meniu de switch pentru fiecare caz (de la 5 la 0 inimi/vieti)
        switch (Health)
        {
            case 5:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                hearts[3].gameObject.SetActive(true);
                hearts[4].gameObject.SetActive(true);
                break;
            case 4:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                hearts[3].gameObject.SetActive(true);
                hearts[4].gameObject.SetActive(false);
                break;
            case 3:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                hearts[3].gameObject.SetActive(false);
                hearts[4].gameObject.SetActive(false);
                break;
            case 2:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
                hearts[4].gameObject.SetActive(false);
                break;
            case 1:
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
                hearts[4].gameObject.SetActive(false);
                break;
            case 0:
                hearts[0].gameObject.SetActive(false);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
                hearts[4].gameObject.SetActive(false);

                // avem 0 vieti/inimi
                // dam play la scena de lose
                //StartCoroutine(LoadLevel());
                break;
        }
    }

    // functie pentru trimiterea catre scena de lose
    /*
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2);
        completeLevelUI.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(index);
    }
    */
}
