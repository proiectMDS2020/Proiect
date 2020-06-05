using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // acest script "semnaleaza" cand jucatorul a terminat nivelul si poate trece mai departe

    private int index; // numarul scenei care urmeaza sa fie incarcata
    public GameObject completeLevelUI; // referinta la canvasul ce va afisa mesajul "Level Finished"
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // verifica daca a atins trofeul de la finalul nivelului
        if (collision.collider.name == "End")
        {
            StartCoroutine(LoadLevel());
        }
    }
   
    // incarca urmatoarea scena
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2);
        // activeaza canvasul
        completeLevelUI.SetActive(true);
        // il lasa sa ruleze doua secunde
        yield return new WaitForSeconds(2);
        // pana incarca urmatoarea scena
        SceneManager.LoadScene(index);
    }
}
