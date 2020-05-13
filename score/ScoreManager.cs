using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public GameObject text;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
        if (health.Health>3)
        {
            score += 50;
        }
    }

    public void ChangeScore(int CoinValue)
    {
        score += CoinValue;
        text.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
