using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController2 : MonoBehaviour
{
    public Transform playerCam;
    public float speed = 1.5f;
    public float zoomSpeed = 2.0f;
    public float zoom = 0.0f;

    private float X;
    private float Y;

    void Update()
    {
        Vector3 pos = transform.position;

        float updatedZoom = zoom;
        updatedZoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (updatedZoom < zoom)
        {
            zoom = updatedZoom;
            pos.y -= 2.0f * Time.deltaTime;
            if (pos.y < 1.0f)
                pos.y = 1.0f;
        }
        else if(updatedZoom > zoom)
        {
            zoom = updatedZoom;
            pos.y += 2.0f * Time.deltaTime;
            if (pos.y > 10.5f)
                pos.y = 10.5f;
        }


        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.z -= 20 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.z += 20 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pos.x += 20 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            pos.x -= 20 * Time.deltaTime;
        }

        transform.position = pos;


    }
}
