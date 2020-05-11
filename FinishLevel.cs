using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private int index;
    public GameObject completeLevelUI;
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "End")
        {
            StartCoroutine(LoadLevel());
        }
    }
   

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2);
        completeLevelUI.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(index);
    }
}
