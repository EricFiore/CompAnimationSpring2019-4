using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupThreePlayThree : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Transform roomThreeGoal;
    public DirectorRoomThree _directorRoomThree;

    private float speed = 1.0f;
    private float runningSpeed = 2.5f;
    private float rotSpeed = 80;
    private float rot = 0f;
    private float gravity = 8;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        controller = GetComponent<CharacterController>();
        navMeshAgent.destination = roomThreeGoal.position;
        anim = GetComponent<Animator>();
        anim.SetInteger("condition", 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            anim.SetInteger("condition", 1);
        }
        if (other.gameObject.tag == "walkObject")
        {
            anim.SetInteger("condition", 1);
        }
        if (other.gameObject.tag == "idleObject")
        {
            anim.SetInteger("condition", 0);
        }
    }

    void onTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            anim.SetInteger("condition", 0);
        }
    }

    void update()
    {
        //if (Vector3.Distance(transform.position, destinationHit.point) <= 0)
        //{
        //    deselectPlayer();
        //}

    }

    public void setPlayer()
    {

    }

    public void deselectPlayer()
    {
        anim.SetInteger("condition", 0);
    }

    public Vector3 getPlayerPosition()
    {
        return transform.position;
    }

    public void stop()
    {
        anim.SetInteger("condition", 0);
        navMeshAgent.Stop();
    }

    public void resume()
    {
        if (Vector3.Distance(roomThreeGoal.position, transform.position) < 4.0f)
        {
            Debug.Log("close to goal");
            anim.SetInteger("condition", 0);
            navMeshAgent.Stop();
        }
        else
        {
            anim.SetInteger("condition", 1);
            navMeshAgent.Resume();
        }

    }

    public void movePlayer(RaycastHit destinationHit)
    {
        //navMeshAgent.destination = destinationHit.point;
        //navMeshAgent.Resume();
        anim.SetBool("walking", true);
        anim.SetInteger("condition", 3);
        anim.SetInteger("condition", 1);
    }
    //public void runPlayer(RaycastHit destinationHit)
    //{
    //    //navMeshAgent.destination = destinationHit.point;
    //    //navMeshAgent.speed = 8.0f;
    //    navMeshAgent.Resume();
    //    anim.SetInteger("condition", 6);
    //}
}
