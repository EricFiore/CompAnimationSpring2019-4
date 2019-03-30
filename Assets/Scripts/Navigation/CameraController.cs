using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    public float cameraRotationSpeed;
    public Transform player;
    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.position - transform.position;                      //get initial distance from player camera is located
        pivot.transform.position = player.transform.position;                //set position of pivot point the same as player
        pivot.transform.parent = player.transform;                          //ensure pivot point is a child of the player
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            float horizontal = Input.GetAxis("Mouse X") * cameraRotationSpeed;  //get x position of the mouse
            pivot.Rotate(0, horizontal, 0);                                    //rotate player
            float vertical = Input.GetAxis("Mouse Y") * cameraRotationSpeed;
            pivot.Rotate(vertical, 0, 0);
            float cameraVerticalAngle = pivot.eulerAngles.y;                   //get players y axis
            float cameraHorizontalAngle = pivot.eulerAngles.x;
            Quaternion rotation = Quaternion.Euler(-cameraHorizontalAngle, cameraVerticalAngle, 0);  //get new quaternion
            transform.position = pivot.position - (rotation * offset);         //get camera position
        }
        else
            transform.position = player.position - offset;                      //ensure camera is positions at a set distance from player


        transform.LookAt(player);                                           //ensure camera is always looking at player
    }
}
