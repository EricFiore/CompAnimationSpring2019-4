using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	public LayerMask whatCanBeClickedOn;
	public LayerMask player;
	private NavMeshAgent myAgent;
	RaycastHit hitInfo;
	RaycastHit playerHit;
	Ray myRay;
	Ray myRayPlayer;
	public Material highlightMaterial; 
	public Material normalColor;

    void Start()
    {
        myAgent = GetComponent <NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
		myAgent.GetComponent<MeshRenderer>().material = normalColor;
		
		if(Input.GetMouseButtonDown (0))
		{
			myRayPlayer = Camera.main.ScreenPointToRay (Input.mousePosition);
		}
		
		if(Physics.Raycast (myRayPlayer, out hitInfo, 100, player))
		{
			myAgent.GetComponent<MeshRenderer>().material = highlightMaterial;
			
			if(Input.GetMouseButtonDown (1))
			{
				myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
				
				if(Physics.Raycast (myRay, out hitInfo, 100, whatCanBeClickedOn))
				{	
					myAgent.SetDestination (hitInfo.point);
				}
								
			}
		
		}
		
		
    }
	
}
