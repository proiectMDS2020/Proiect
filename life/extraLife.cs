using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraLife : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.Health += 1;
            Destroy(gameObject);
        }
    }
}
