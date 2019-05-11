using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{

    private float speed = 5.0f;
    private float rotSpeed = 100.0f;
    private Vector3 moveDir = Vector3.zero;
    private float gravity = 8.0f;
    private CharacterController controller;

    public TwoHeroController twoHeroController;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (twoHeroController.getPlayerOneStatus())
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 0);
            }
            rotSpeed += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rotSpeed, 0);
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }
}
