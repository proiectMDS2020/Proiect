using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    // se intoarce la meniul principal
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // reia jocul de la nivelul 1
    public void RestartGame()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene(1);
    }
}
