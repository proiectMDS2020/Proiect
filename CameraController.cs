using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var tempCamera = transform.position;
        var tempPlayer = player.transform.position;
        tempCamera.x = tempPlayer.x + offset.x;
        transform.position = tempCamera;
    }
}