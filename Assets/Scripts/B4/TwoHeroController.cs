using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHeroController : MonoBehaviour
{
    private bool playerOneSelected;
    private bool playerTwoSelected;

    public PlayerOneController _playerOneController;
    public PlayerTwoController _playerTwoController;

    // Start is called before the first frame update
    void Start()
    {
        playerOneSelected = false;
        playerTwoSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("this is in two hero controller");
            RaycastHit hit;
            Ray selectingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //if (Physics.Raycast(selectingRay, out hit, 100))
            //{
            //    if (hit.collider != null)
            //    {
            //        Debug.Log("not null");
            //    }
            //    if (hit.collider.CompareTag("HeroOne") && playerOneSelected)
            //    {
            //        playerOneSelected = false;
            //        Debug.Log("player one is " + playerOneSelected);
            //    }
            //    else if (hit.collider.CompareTag("PlayerOne") && !playerOneSelected)
            //    {
            //        playerOneSelected = true;
            //        Debug.Log("player one is " + playerOneSelected);
            //    }
            //    if (hit.collider.CompareTag("PlayerTwo") && playerTwoSelected)
            //    {
            //        playerTwoSelected = false;
            //        Debug.Log("player two is " + playerTwoSelected);
            //    }
            //    else if (hit.collider.CompareTag("PlayerTwo") && !playerTwoSelected)
            //    {
            //        playerTwoSelected = true;
            //        Debug.Log("player two is " + playerTwoSelected);
            //    }
            }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!playerOneSelected)
            {
                playerOneSelected = true;
                playerTwoSelected = false;
                Debug.Log("player one is " + playerOneSelected + " and player two is " + playerTwoSelected);
            }
            else
            {
                playerOneSelected = false;
                playerTwoSelected = true;
                Debug.Log("test player one is " + playerOneSelected + " and player two is " + playerTwoSelected);
            }
        }
    }

    public bool getPlayerOneStatus()
    {
        return playerOneSelected;
    }
    public bool getPlayerTwoStatus()
    {
        return playerTwoSelected;
    }
}

