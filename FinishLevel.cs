using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // acest script "semnaleaza" cand jucatorul a terminat nivelul si poate trece mai departe
    
    private bool getExtra = false;
    public bool tag;
    private int index; // numarul scenei care urmeaza sa fie incarcata
    public GameObject completeLevelUI; // referinta la canvasul ce va afisa mesajul "Level Finished"


    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == false)
        {
            // verifica daca a atins trofeul de la finalul nivelului
            if (collision.collider.name == "End")
            {
                if (health.Health>3)
                {  
                    if (getExtra == false)
                    {
                        ScoreManager.instance.ExtraPoints();
                        getExtra = true;
                    }
                }
                StartCoroutine(LoadLevel());
            }
        }
        else
        {
            if (collision.collider.tag == "End")
            {
                if (health.Health>3)
                {
                    if (getExtra == false)
                    {
                        ScoreManager.instance.ExtraPoints();
                        getExtra = true;
                    }
                }
                StartCoroutine(LoadLevel());
            }
        }
    }
   
    // incarca urmatoarea scena
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.5f);
        // activeaza canvasul
        completeLevelUI.SetActive(true);
        // il lasa sa ruleze doua secunde
        yield return new WaitForSeconds(2);
        // pana incarca urmatoarea scena
        SceneManager.LoadScene(index);
    }
}
