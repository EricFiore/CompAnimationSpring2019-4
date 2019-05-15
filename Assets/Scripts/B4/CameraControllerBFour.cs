using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBFour : MonoBehaviour
{
    public float speed = 1.5f;
    private float X;
    private float Y;

    void Update()
    {
        Debug.Log("this should print");

        Vector3 pos = transform.position;

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.z -= 20 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.z += 20 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up arrow");
            pos.x += 20 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.x -= 20 * Time.deltaTime;
        }

        transform.position = pos;


    }
}
