using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform DanielHead;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - DanielHead.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = DanielHead.position + offset;
        //transform.rotation = DanielHead.rotation;
    }
}
