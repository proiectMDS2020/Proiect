using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraLife : MonoBehaviour
{

    public bool hasTouched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTouched == false)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                health.Health += 1;
                Destroy(gameObject);
                hasTouched = true;
            }
        }

    }
}
