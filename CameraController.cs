using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // acest script face camera sa urmareasca jucatorul 

    public GameObject player; // referinta la obiectul jucator
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position; // distanta initiala dintre camera si jucator
    }

    void LateUpdate()
    {
        var tempCamera = transform.position; // variabila auxiliara pentru pozitia camerei
        var tempPlayer = player.transform.position; // variabila auxiliara pentru pozitia jucatorului
        tempCamera.x = tempPlayer.x + offset.x; // se actualizeaza in variabila auxiliara valoare pe axa Ox conform miscarii jucatorului
        transform.position = tempCamera; 
    }
}
