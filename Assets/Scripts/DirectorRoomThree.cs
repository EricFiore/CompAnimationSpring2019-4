using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorRoomThree : MonoBehaviour
{
    public GroupThreePlayOne _groupThreePlayOne;
    public GroupThreePlayTwo _groupThreePlayTwo;
    public GroupThreePlayThree _groupThreePlayThree;

    private Vector3 playerOnePosition;
    private Vector3 playerTwoPosition;
    private Vector3 playerThreePosition;
    private bool playerOneTwoClose, playerOneThreeClose, playerOneFourClose,
        playerTwoThreeClose;
    private bool playerOneClose, playerTwoClose, playerThreeClose;

    // Start is called before the first frame update
    void Start()
    {
        playerOneClose = false;
        playerTwoClose = false;
        playerThreeClose = false;
        playerOneTwoClose = false;
        playerOneThreeClose = false;
        playerOneFourClose = false;
        playerTwoThreeClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerOnePosition = _groupThreePlayOne.getPlayerPosition();
        playerTwoPosition = _groupThreePlayTwo.getPlayerPosition();
        playerThreePosition = _groupThreePlayThree.getPlayerPosition();
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
        if (Vector3.Distance(playerTwoPosition, playerThreePosition) < 5.0f)
        {
            playerTwoThreeClose = true;
        }
        else
        {
            playerTwoThreeClose = false;
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
    }

    public void brakePlayer()
    {
        if (playerTwoClose)
        {
            _groupThreePlayTwo.stop();
        }
        else
        {
            _groupThreePlayTwo.resume();
        }
        if (playerThreeClose)
        {
            _groupThreePlayThree.stop();
        }
        else
        {
            _groupThreePlayThree.resume();
        }
    }
}