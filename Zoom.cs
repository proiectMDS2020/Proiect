using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zoom : MonoBehaviour
{
    // acest script va face zoom (in scena in care sunt prezentate toate cele 5 nivele) pe scena care urmeaza
    private int index; // va indicata numarul de ordine al scenei care va fi incarcata 
    public Animator animator;
    public Transform panel;
    public RectTransform panelRectTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        index = SceneManager.GetActiveScene().buildIndex + 1;
        // exista cate o animatie pentru fiecare nivel (indicand unde pe plansa sa dea zoom) 
        // aceasta este numita ZoomInLeveln, unde n apartine {1, 2, 3, 4, 5}
        animator.Play("ZoomInLevel" + index / 2);
        StartCoroutine(LoadLevel());
    }

    // incarca dupa 6 secunde scena indicata de index
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(index);
    }
}
