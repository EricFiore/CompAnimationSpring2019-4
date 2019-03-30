using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2CameraController : MonoBehaviour
{
    public Transform playerCam, character, centerPoint;
    public float mouseSpeed = 10.0f;
    public float moveSpeed = 2.0f;
    public float zoomSpeed = 2.0f;

    private float zoomMin = -1.5f, zoomMax = -4.0f;
    private float mouseX, mouseY;
    private float moveFB, moveLR;
    private float zoom;
    private float rotationSpeed = 2.0f;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        zoom = -3.0f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (zoom > zoomMin)
        {
            zoom = zoomMin;
        }
        if (zoom < zoomMax)
        {
            zoom = zoomMax;
        }

        playerCam.transform.localPosition = new Vector3(0, 0, zoom);

        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY -= Input.GetAxis("Mouse Y");
        }

        mouseY = Mathf.Clamp(mouseY, -60.0f, 60.0f);
        playerCam.LookAt(centerPoint);
        centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);


        //moveFB = Input.GetAxis("Vertical") * moveSpeed;
        //moveLR = Input.GetAxis("Horizontal") * moveSpeed;
        //Vector3 movement = new Vector3(moveLR, 0, moveFB);
        //movement = character.rotation * movement;
        //character.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        centerPoint.TransformDirection(character.position.x, character.position.y + 1.5f, character.position.z);

        //if (Input.GetAxis("Vertical") > 0 | Input.GetAxis("Vertical") < 0)
        //{
        //    Quaternion turnAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);
        //    character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);
        //}
    }
}
