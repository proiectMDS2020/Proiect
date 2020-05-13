using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int CoinValue;
    public bool hasTouched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(hasTouched==false)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                ScoreManager.instance.ChangeScore(CoinValue);
                Destroy(gameObject);
                hasTouched = true;
            } 
        }
        
    }
}
