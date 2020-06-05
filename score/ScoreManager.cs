using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    //Obiect pentru afisarea scorului in permanenta pe ecran
    public GameObject text;
    //Variabila care contorizeaza scorul
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    //Functie care modifica valoarea scorului si afisarea lui
    //Functia primeste valoarea banutului strans, valoare trimisa din clasa Coin
    public void ChangeScore(int CoinValue)
    {
        //Se aduna la scorul curent valoarea primita ca parametru
        score += CoinValue;
        //Se afiseaza scorul actualizat
        text.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
