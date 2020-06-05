using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovingPlatform  : MonoBehaviour
{

    private Vector3 posA; //variabila utilizata pentru a salva pozitia initiala a placutei

    private Vector3 posB; //variabila utilizata pentru a salva pozitia obiectului pana la care se misca placuta 

    private Vector3 nextPos; //variabila utilizata pentru a indica spre ce punct trebuie sa mearga placuta 

    [SerializeField]
    private float speed; //viteza cu care se va misca placuta

    [SerializeField]
    private Transform objectTransform; //placuta care se misca

    [SerializeField]
    private Transform transformB; //obiectul pana la care ajunge placuta



    void Start()
    {
        posA = objectTransform.localPosition; // se salveaza pozitia initiala a placutei
        posB = transformB.localPosition; //se salveaza pozitia obiectului pana la care se misca placuta 
        nextPos = posB; //setam pozitia unde trebuie sa ajunga placuta 


    }

    void Update()
    {
        Move();

    }

    private void Move()
    {
        objectTransform.localPosition = Vector3.MoveTowards(objectTransform.localPosition, nextPos, speed * Time.deltaTime); //muta placuta spre punctul indicat de nextPos cu viteza speed
        
        //cand ajunge la o distanta mai mica sau egala cu 0,1 schimba pozitia spre care se indreapta
        if(Vector3.Distance(objectTransform.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        //functie utilizata pentru a schimba pozitia
        nextPos = nextPos != posA ? posA : posB;
    }


}
