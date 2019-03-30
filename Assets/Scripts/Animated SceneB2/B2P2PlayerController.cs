using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2P2PlayerController : MonoBehaviour
{
    private Ray shootRay;
    private RaycastHit destination;
    private Ray myRayPlayer;
    private bool playerOneSelected;
    private bool runPlayer;
    private Vector3 destinationPoint;

    public B2P2PlayerMove _B2P2PlayerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerOneSelected = false;
        runPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray selectingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(selectingRay, out hit, 100))
            {
                if (hit.collider.CompareTag("PlayerOne") && !playerOneSelected)
                {
                    playerOneSelected = true;
                    runPlayer = false;
                    _B2P2PlayerMove.setPlayer();
                }
                else if (hit.collider.CompareTag("PlayerOne") && !runPlayer)
                {
                    runPlayer = true;
                    playerOneSelected = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && (playerOneSelected || runPlayer))
        {
            playerOneSelected = false;
            runPlayer = false;
            _B2P2PlayerMove.deselectPlayer();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Ray selectingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(selectingRay, out hit, 100))
            {
                destinationPoint = hit.point;
                if (hit.collider.CompareTag("Floor") && playerOneSelected)
                {
                    Debug.Log("floor and walk");
                    _B2P2PlayerMove.movePlayer(hit);
                }
                else if (hit.collider.CompareTag("Floor") && runPlayer)
                {
                    Debug.Log("floor and run");
                    _B2P2PlayerMove.runPlayer(hit);
                }
            }
        }
        if (_B2P2PlayerMove.transform.position.x == destinationPoint.x)
        {
            if (_B2P2PlayerMove.transform.position.z == destinationPoint.z)
            {
                _B2P2PlayerMove.deselectPlayer();
            }
        }
    }
}
