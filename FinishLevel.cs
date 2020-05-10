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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndLevel")
        {
            StartCoroutine(LoadLevel());
        }
    }

    private void Update()
    {
        Debug.Log(gameObject.transform.position);
        if (transform.position.x > 144)
        {
            Debug.Log('a');
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
