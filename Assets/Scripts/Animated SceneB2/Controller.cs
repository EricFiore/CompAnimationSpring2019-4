using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float speed = 1;
    float runningSpeed = 2.5f;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 8;

    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walking();
        running();
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            if (anim.GetBool("walking") == true)
            {
                anim.SetBool("walking", false);
                anim.SetInteger("condition", 0);
            }
            if (anim.GetBool("walking") == false)
            {
                Jump();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            turnLeft();
        }
        if (Input.GetKeyUp(KeyCode.A) && anim.GetBool("turnLeft"))
        {
            stopTurningLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            turnRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            stopTurningRight();
        }
        if (Input.GetKey(KeyCode.S))
        {
            walkBackwards();
        }
        if (Input.GetKey(KeyCode.W))
        {
            Walking();
        }
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.W))
        {
            running();
        }

        if (Input.GetKey(KeyCode.E))
        {
            SFRight();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SFLeft();
        }

        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.W))
        {
            SFRight();
            Walking();
        }

        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.W))
        {
            SFLeft();
            Walking();
        }


    }

    void turnRight()
    {
        anim.SetBool("turnRight", true);
        anim.SetInteger("condition", 4);
    }

    void stopTurningRight()
    {
        anim.SetBool("turnRight", false);
        anim.SetInteger("condition", 0);
    }
    void turnLeft()
    {
        anim.SetBool("turnLeft", true);
        anim.SetInteger("condition", 3);
    }

    void stopTurningLeft()
    {
        anim.SetBool("turnLeft", false);
        anim.SetInteger("condition", 0);
    }

    void Jump()
    {
        StartCoroutine(JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        anim.SetBool("jumping", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds(0.2f);
        anim.SetInteger("condition", 0);
        anim.SetBool("jumping", false);
    }

    void running()
    {
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.W))
        {
            if (anim.GetBool("jumping") == true)
            {
                return;
            }
            else if (anim.GetBool("jumping") == false)
            {
                anim.SetBool("running", true);
                anim.SetInteger("condition", 6); //invokes walk animation
                moveDir = new Vector3(0, 0, 1);
                moveDir *= runningSpeed;
                moveDir = transform.TransformDirection(moveDir);
            }
        }

        else
        {
            anim.SetBool("running", false);
            anim.SetInteger("condition", 0); // stops walk animation
            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }


    void SFRight()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (anim.GetBool("jumping") == true)
            {
                return;
            }
            else if (anim.GetBool("jumping") == false)
            {
                //anim.SetBool("running", true);
                anim.SetInteger("condition", 3); //invokes walk animation
                moveDir = new Vector3(1, 0, 0);
                moveDir *= runningSpeed;
                moveDir = transform.TransformDirection(moveDir);
            }
        }

        else
        {
            //anim.SetBool("running", false);
            anim.SetInteger("condition", 0); // stops walk animation
            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void SFLeft()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (anim.GetBool("jumping") == true)
            {
                return;
            }
            else if (anim.GetBool("jumping") == false)
            {
                //anim.SetBool("running", true);
                anim.SetInteger("condition", 3); //invokes walk animation
                moveDir = new Vector3(-1, 0, 0);
                moveDir *= runningSpeed;
                moveDir = transform.TransformDirection(moveDir);
            }
        }

        else
        {
            //anim.SetBool("running", false);
            anim.SetInteger("condition", 0); // stops walk animation
            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void Walking()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (anim.GetBool("jumping") == true)
            {
                return;
            }

            else if (anim.GetBool("jumping") == false)
            {
                anim.SetBool("walking", true);
                anim.SetInteger("condition", 1); //invokes walk animation
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
        }
        else
        {
            anim.SetBool("walking", false);
            anim.SetInteger("condition", 0); // stops walk animation
            moveDir = new Vector3(0, 0, 0);
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
    private void walkBackwards()
    {
        if (anim.GetBool("jumping"))
        {
            return;
        }
        else
        {
            anim.SetBool("walkingBackwards", true);
            anim.SetInteger("condition", 5);
            moveDir = new Vector3(0, 0, -1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}








//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Controller : MonoBehaviour
//{
//    float speed = 1;
//    float runningSpeed = 2.5f;
//    float rotSpeed = 80;
//    float rot = 0f;
//    float gravity = 8;

//    Vector3 moveDir = Vector3.zero;
//    CharacterController controller;
//    Animator anim;

//    // Start is called before the first frame update
//    void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Walking();
//        running();
//        GetInput();
//    }

//    void GetInput()
//    {
//            if (Input.GetKey(KeyCode.Space))
//            {

//                if (anim.GetBool("walking") == true)
//                {
//                    anim.SetBool("walking", false);
//                    anim.SetInteger("condition", 0);
//                }
//                if (anim.GetBool("walking") == false)
//                {
//                    Jump();
//                }
//            }
//            if (Input.GetKey(KeyCode.A))
//            {
//                turnLeft();
//            }
//            if (Input.GetKeyUp(KeyCode.A) && anim.GetBool("turnLeft"))
//            {
//                stopTurningLeft();
//            }
//            if (Input.GetKey(KeyCode.D))
//            {
//                turnRight();
//            }
//            if (Input.GetKeyUp(KeyCode.D))
//            {
//                stopTurningRight();
//            }
//            if (Input.GetKey(KeyCode.S))
//            {
//                walkBackwards();
//            }
//            if (Input.GetKey(KeyCode.W))
//            {
//                Walking();
//            }
//            if (Input.GetKey(KeyCode.G))
//            {
//                running();
//            }

//			if (Input.GetKey(KeyCode.E))
//            {
//                SFRight();
//            }

//			if (Input.GetKey(KeyCode.Q))
//            {
//                SFLeft();
//            }

//			if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.W))
//            {
//                SFRight();
//				Walking();
//            }

//			if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.W))
//            {
//                SFLeft();
//				Walking();
//            }


//    }

//    void turnRight()
//    {
//        anim.SetBool("turnRight", true);
//        anim.SetInteger("condition", 4);
//    }

//    void stopTurningRight()
//    {
//        anim.SetBool("turnRight", false);
//        anim.SetInteger("condition", 0);
//    }
//    void turnLeft()
//    {
//        anim.SetBool("turnLeft", true);
//        anim.SetInteger("condition", 3);
//    }

//    void stopTurningLeft()
//    {
//        anim.SetBool("turnLeft", false);
//        anim.SetInteger("condition", 0);
//    }

//    void Jump()
//    {
//        StartCoroutine(JumpRoutine());
//    }

//    IEnumerator JumpRoutine()
//    {
//        anim.SetBool("jumping", true);
//        anim.SetInteger("condition", 2);
//        yield return new WaitForSeconds(0.2f);
//        anim.SetInteger("condition", 0);
//        anim.SetBool("jumping", false);
//    }

//    void running()
//    {
//            if (Input.GetKey(KeyCode.G))
//            {
//                if (anim.GetBool("jumping") == true)
//                {
//                    return;
//                }
//                else if (anim.GetBool("jumping") == false)
//                {
//                    anim.SetBool("running", true);
//                    anim.SetInteger("condition", 6); //invokes walk animation
//                    moveDir = new Vector3(0, 0, 1);
//                    moveDir *= runningSpeed;
//                    moveDir = transform.TransformDirection(moveDir);
//                }
//            }

//            else
//            {
//                anim.SetBool("running", false);
//                anim.SetInteger("condition", 0); // stops walk animation
//                moveDir = new Vector3(0, 0, 0);
//            }

//        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
//        transform.eulerAngles = new Vector3(0, rot, 0);
//        moveDir.y -= gravity * Time.deltaTime;
//        controller.Move(moveDir * Time.deltaTime);
//    }


//	void SFRight()
//    {
//            if (Input.GetKey(KeyCode.E))
//            {
//                if (anim.GetBool("jumping") == true)
//                {
//                    return;
//                }
//                else if (anim.GetBool("jumping") == false)
//                {
//                    //anim.SetBool("running", true);
//                    anim.SetInteger("condition", 3); //invokes walk animation
//                    moveDir = new Vector3(1, 0, 0);
//                    moveDir *= runningSpeed;
//                    moveDir = transform.TransformDirection(moveDir);
//                }
//            }

//            else
//            {
//                //anim.SetBool("running", false);
//                anim.SetInteger("condition", 0); // stops walk animation
//                moveDir = new Vector3(0, 0, 0);
//            }

//        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
//        transform.eulerAngles = new Vector3(0, rot, 0);
//        moveDir.y -= gravity * Time.deltaTime;
//        controller.Move(moveDir * Time.deltaTime);
//    }

//	void SFLeft()
//    {
//            if (Input.GetKey(KeyCode.Q))
//            {
//                if (anim.GetBool("jumping") == true)
//                {
//                    return;
//                }
//                else if (anim.GetBool("jumping") == false)
//                {
//                    //anim.SetBool("running", true);
//                    anim.SetInteger("condition", 3); //invokes walk animation
//                    moveDir = new Vector3(-1, 0, 0);
//                    moveDir *= runningSpeed;
//                    moveDir = transform.TransformDirection(moveDir);
//                }
//            }

//            else
//            {
//                //anim.SetBool("running", false);
//                anim.SetInteger("condition", 0); // stops walk animation
//                moveDir = new Vector3(0, 0, 0);
//            }

//        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
//        transform.eulerAngles = new Vector3(0, rot, 0);
//        moveDir.y -= gravity * Time.deltaTime;
//        controller.Move(moveDir * Time.deltaTime);
//    }

//    void Walking()
//    {
//            if (Input.GetKey(KeyCode.W))
//            {
//                if (anim.GetBool("jumping") == true)
//                {
//                    return;
//                }

//                else if (anim.GetBool("jumping") == false)
//                {
//                    anim.SetBool("walking", true);
//                    anim.SetInteger("condition", 1); //invokes walk animation
//                    moveDir = new Vector3(0, 0, 1);
//                    moveDir *= speed;
//                    moveDir = transform.TransformDirection(moveDir);
//                }
//            }
//            else
//            {
//                anim.SetBool("walking", false);
//                anim.SetInteger("condition", 0); // stops walk animation
//                moveDir = new Vector3(0, 0, 0);
//            }
//        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
//        transform.eulerAngles = new Vector3(0, rot, 0);
//        moveDir.y -= gravity * Time.deltaTime;
//        controller.Move(moveDir * Time.deltaTime);
//    }
//    private void walkBackwards()
//    {
//        if (anim.GetBool("jumping"))
//        {
//            return;
//        }
//        else
//        {
//            anim.SetBool("walkingBackwards", true);
//			anim.SetInteger("condition", 5);
//            moveDir = new Vector3(0, 0, -1);
//            moveDir *= speed;
//            moveDir = transform.TransformDirection(moveDir);
//        }
//        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
//        transform.eulerAngles = new Vector3(0, rot, 0);
//        moveDir.y -= gravity * Time.deltaTime;
//        controller.Move(moveDir * Time.deltaTime);
//    }
//}
