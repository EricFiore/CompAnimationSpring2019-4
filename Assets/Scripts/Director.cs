using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Director : MonoBehaviour
{
    public GroupOnePlayOne _groupOnePlayOne;
    public GroupOnePlayTwo _groupOnePlayTwo;
    public GroupOnePlayThree _groupOnePlayThree;
    public GroupOnePlayFour _groupOnePlayFour;

    private Vector3 playerOnePosition;
    private Vector3 playerTwoPosition;
    private Vector3 playerThreePosition;
    private Vector3 playerFourPosition;
    private bool playerOneTwoClose, playerOneThreeClose, playerOneFourClose,
        playerTwoThreeClose, playerTwoFourClose, playerThreeFourClose;
    private bool playerOneClose, playerTwoClose, playerThreeClose, playerFourClose;

    // Start is called before the first frame update
    void Start()
    {
        playerOneClose = false;
        playerTwoClose = false;
        playerThreeClose = false;
        playerFourClose = false;
        playerOneTwoClose = false;
        playerOneThreeClose = false;
        playerOneFourClose = false;
        playerTwoThreeClose = false;
        playerTwoFourClose = false;
        playerThreeFourClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerOnePosition = _groupOnePlayOne.getPlayerPosition();
        playerTwoPosition = _groupOnePlayTwo.getPlayerPosition();
        playerThreePosition = _groupOnePlayThree.getPlayerPosition();
        playerFourPosition = _groupOnePlayFour.getPlayerPosition();
        checkDistance();
        brakePlayer();
    }

    public void checkDistance()
    {
        if (Vector3.Distance(playerOnePosition, playerTwoPosition) < 5.0f)
        {
            playerOneTwoClose = true;
        }
        else
        {
            playerOneTwoClose = false;
        }
        if (Vector3.Distance(playerOnePosition, playerThreePosition) < 5.0f)
        {
            playerOneThreeClose = true;
        }
        else
        {
            playerOneThreeClose = false;
        }
        if (Vector3.Distance(playerOnePosition, playerFourPosition) < 5.0f)
        {
            playerOneFourClose = true;
        }
        else
        {
            playerOneFourClose = false;
        }
        if (Vector3.Distance(playerTwoPosition, playerThreePosition) < 5.0f)
        {
            playerTwoThreeClose = true;
        }
        else
        {
            playerTwoThreeClose = false;
        }
        if (Vector3.Distance(playerTwoPosition, playerFourPosition) < 5.0f)
        {
            playerTwoFourClose = true;
        }
        else
        {
            playerTwoFourClose = false;
        }
        if (Vector3.Distance(playerThreePosition, playerFourPosition) < 5.0f)
        {
            playerThreeFourClose = true;
        }
        else
        {
            playerThreeFourClose = false;
        }
        if (playerOneTwoClose)
        {
            playerTwoClose = true;
        }
        else
        {
            playerTwoClose = false;
        }
        if (playerOneThreeClose || playerTwoThreeClose)
        {
            playerThreeClose = true;
        }
        else
        {
            playerThreeClose = false;
        }
        if (playerOneFourClose || playerTwoFourClose || playerThreeFourClose)
        {
            playerFourClose = true;
        }
        else
        {
            playerFourClose = false;
        }
    }

    public void brakePlayer()
    {
        if (playerTwoClose)
        {
            _groupOnePlayTwo.stop();
        }
        else
        {
            _groupOnePlayTwo.resume();
        }
        if (playerThreeClose)
        {
            _groupOnePlayThree.stop();
        }
        else
        {
            _groupOnePlayThree.resume();
        }
        if (playerFourClose)
        {
            _groupOnePlayFour.stop();
        }
        else
        {
            _groupOnePlayFour.resume();
        }
    }
}
