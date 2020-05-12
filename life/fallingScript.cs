using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingScript : MonoBehaviour
{
    public GameObject spawn;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            health.Health -= 1;
            col.transform.position = spawn.transform.position;
        }
    }
}
