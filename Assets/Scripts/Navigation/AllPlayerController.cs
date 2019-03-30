using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerController : MonoBehaviour
{
    private LayerMask clickablesLayer;
    private Ray shootRay;
    private RaycastHit destination;
    private Ray myRayPlayer;
    private bool playerOneSelected;
    private bool playerTwoSelected;
    private bool playerThreeSelected;
    private bool playerFourSelected;
    private bool playerFiveSelected;
    private bool barrelOneSelected;
    private bool barrelTwoSelected;
    private bool barrelThreeSelected;
    private MeshRenderer renderer;
    public PlayControl _playControl;
    public PlayControlTwo _playControlTwo;
    public PlayControlThree _playControlThree;
    public PlayControlFour _playControlFour;
    public PlayControlFive _playControlFive;
    public MoveBarrel _moveBarrel;
    public MoveBarrelTwo _moveBarrelTwo;
    public MoveBarrelThree _moveBarrelThree;

    public void start()
    {
        playerOneSelected = false;
        playerTwoSelected = false;
        playerThreeSelected = false;
        playerFourSelected = false;
        playerFiveSelected = false;
        barrelOneSelected = false;
        barrelTwoSelected = true;
        barrelThreeSelected = true;
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray selectingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(selectingRay, out hit, 100))
            {
                if(hit.collider.CompareTag("PlayerOne") && playerOneSelected)
                {
                    _playControl.deselectPlayer();
                    playerOneSelected = false;
                }
                else if (hit.collider.CompareTag("PlayerOne") && !playerOneSelected)
                {
                    _playControl.setPlayer();
                    playerOneSelected = true;
                }
                if (hit.collider.CompareTag("PlayerTwo") && playerTwoSelected)
                {
                    _playControlTwo.deselectPlayer();
                    playerTwoSelected = false;
                }
                else if (hit.collider.CompareTag("PlayerTwo") && !playerTwoSelected)
                {
                    _playControlTwo.setPlayer();
                    playerTwoSelected = true;
                }
                if (hit.collider.CompareTag("PlayerThree") && playerThreeSelected)
                {
                    _playControlThree.deselectPlayer();
                    playerThreeSelected = false;
                }
                else if (hit.collider.CompareTag("PlayerThree") && !playerThreeSelected)
                {
                    _playControlThree.setPlayer();
                    playerThreeSelected = true;
                }
                if (hit.collider.CompareTag("PlayerFour") && playerFourSelected)
                {
                    _playControlFour.deselectPlayer();
                    playerFourSelected = false;
                    Debug.Log("player Two is now " + playerThreeSelected);
                }
                else if (hit.collider.CompareTag("PlayerFour") && !playerFourSelected)
                {
                    _playControlFour.setPlayer();
                    playerFourSelected = true;
                }
                if (hit.collider.CompareTag("PlayerFive") && playerFiveSelected)
                {
                    _playControlFive.deselectPlayer();
                    playerFiveSelected = false;
                }
                else if (hit.collider.CompareTag("PlayerFive") && !playerFiveSelected)
                {
                    _playControlFive.setPlayer();
                    playerFiveSelected = true;
                }
                if (hit.collider.CompareTag("BarrelOne") && barrelOneSelected)
                {
                    _moveBarrel.deselectBarrel();
                    barrelOneSelected = false;
                }
                else if (hit.collider.CompareTag("BarrelOne") && !barrelOneSelected)
                {
                    _moveBarrel.selectBarrel();
                    barrelOneSelected = true;
                }
                if (hit.collider.CompareTag("BarrelTwo") && barrelTwoSelected)
                {
                    _moveBarrelTwo.deselectBarrel();
                    barrelTwoSelected = false;
                }
                else if (hit.collider.CompareTag("BarrelTwo") && !barrelTwoSelected)
                {
                    Debug.Log("hit collide has detected");
                    _moveBarrelTwo.selectBarrel();
                    barrelTwoSelected = true;
                }
                if (hit.collider.CompareTag("BarrelThree") && barrelThreeSelected)
                {
                    _moveBarrelThree.deselectBarrel();
                    barrelThreeSelected = false;
                }
                else if (hit.collider.CompareTag("BarrelThree") && !barrelThreeSelected)
                {
                    _moveBarrelThree.selectBarrel();
                    barrelThreeSelected = true;
                }
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Ray selectingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(selectingRay, out hit, 100))
            {
                if (hit.collider.CompareTag("Floor") && playerOneSelected)
                {
                    _playControl.movePlayer(hit);
                }
                if (hit.collider.CompareTag("Floor") && playerTwoSelected)
                {
                    _playControlTwo.movePlayer(hit);
                }
                if (hit.collider.CompareTag("Floor") && playerThreeSelected)
                {
                    _playControlThree.movePlayer(hit);
                }
                if (hit.collider.CompareTag("Floor") && playerFourSelected)
                {
                    _playControlFour.movePlayer(hit);
                }
                if (hit.collider.CompareTag("Floor") && playerFiveSelected)
                {
                    _playControlFive.movePlayer(hit);
                }
            }
        }
    }
}
