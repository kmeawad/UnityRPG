using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float camWidth;
    public float camHeight;

    void Awake()
    {
        //get the camera height and width
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    public void Update()
    {
        
        //get the postion of the player and camera
        Vector3 pos = transform.position;
        Vector3 pos1 = Camera.main.transform.position;

        //if the player is not in the camera frame then change the camera postion to make the player in frame 
        if (pos.x >= (camWidth+pos1.x))
        {
            pos1.x += camWidth*2;
        }

        if (pos.x <= (-camWidth + pos1.x))
        {
            pos1.x -= camWidth*2;
        }

        if (pos.y >= (camHeight+pos1.y))
        {
            pos1.y += camHeight*2;
        }

        if (pos.y <= (-camHeight + pos1.y))
        {
            pos1.y -= camHeight*2;
        }

        Camera.main.transform.position = pos1;
    }
}
