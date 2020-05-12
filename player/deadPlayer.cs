using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class deadPlayer : MonoBehaviour
{
    public static bool dead;

    [SerializeField] Transform SpawnPoint;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);

        if (dead)
        {
            dead = false;
            animator.SetBool("IsDead", true);
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1);
        transform.position = SpawnPoint.position;
        animator.SetBool("IsDead", false);
    }

}
