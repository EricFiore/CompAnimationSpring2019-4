using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneMove : MonoBehaviour
{
    public Material normalColor;
    public Material highlightColor;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Transform agentCenter;
    public Transform roomOneGoal;
    public RaycastHit destinationHit;

    private float speed = 1.0f;
    private float runningSpeed = 2.5f;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 8;

    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        controller = GetComponent<CharacterController>();
        navMeshAgent.destination = roomOneGoal.position;
        Debug.Log("desination one is " + navMeshAgent.destination);
        anim = GetComponent<Animator>();
        anim.SetInteger("condition", 0);    
    }

    void OnTriggerEnter( Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            anim.SetInteger("condition", 2);
        }
        if (other.gameObject.tag == "walkObject")
        {
            anim.SetInteger("condition", 1);
        }
        if (other.gameObject.tag == "jumpWall")
        {
            anim.SetInteger("condition", 2);
        }
        if (other.gameObject.tag == "idleObject")
        {
            anim.SetInteger("condition", 0);
        }
    }

    void onTriggerExit ( Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            anim.SetInteger("condition", 0);
        }
    }

    void update()
    {
        if (Vector3.Distance(transform.position, destinationHit.point) <= 0)
        {
            deselectPlayer();
        }
        
    }
    // Update is called once per frame
    public void setPlayer()
    {
        GetComponent<Renderer>().material = highlightColor;
    }

    public void deselectPlayer()
    {
        anim.SetInteger("condition", 0);
    }

    public void movePlayer(RaycastHit destinationHit)
    {
        //navMeshAgent.destination = destinationHit.point;
        //navMeshAgent.Resume();
        anim.SetBool("walking", true);
        anim.SetInteger("condition", 3);
        anim.SetInteger("condition", 1);
    }
    public void runPlayer(RaycastHit destinationHit)
    {
        //navMeshAgent.destination = destinationHit.point;
        //navMeshAgent.speed = 8.0f;
        navMeshAgent.Resume();
        anim.SetInteger("condition", 6);
    }
}
