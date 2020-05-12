using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public static int Health;

    public Animator[] animator;

    public GameObject[] hearts;


    // Start is called before the first frame update
    void Start()
    {
        Health = 3;

        hearts[0].gameObject.SetActive(true);
        hearts[1].gameObject.SetActive(true);
        hearts[2].gameObject.SetActive(true);
        hearts[3].gameObject.SetActive(false);
        hearts[4].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 5)
        {
            Health = 5;
        }

        switch(Health)
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
                break;
        }
    }
}
