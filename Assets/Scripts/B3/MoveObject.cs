using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    private bool rockOneSelected = false;
    private bool groundRockSelected = false;

    public float force = 5;
    public float speed;
    public RockOneMove _rockOneMove;
    public RockTwoMove _rockTwoMove;
    public RockThreeMove _rockThreeMove;
    public RockFourMove _rockFourMove;
    public RockFiveMove _rockFiveMove;
    public GroundRockOne _groundRockOne;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("moues One pressed");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("physics hit");
                if (hit.collider.CompareTag("rocks") && !rockOneSelected)
                {
                    Debug.Log("rocks detected");
                    _rockOneMove.selectRock();
                    _rockTwoMove.selectRock();
                    _rockThreeMove.selectRock();
                    _rockFourMove.selectRock();
                    _rockFiveMove.selectRock();
                    rockOneSelected = true;
                }
                else if (hit.collider.CompareTag("rocks") && rockOneSelected)
                {
                    _rockOneMove.deselectRock();
                    _rockTwoMove.deselectRock();
                    _rockThreeMove.deselectRock();
                    _rockFourMove.deselectRock();
                    _rockFiveMove.deselectRock();
                    rockOneSelected = false;
                }
                if (hit.collider.CompareTag("groundRock") && !groundRockSelected)
                {
                    Debug.Log("ground rock selected");
                    _groundRockOne.selectRock();
                    groundRockSelected = true;
                }
                else if (hit.collider.CompareTag("groundRock") && groundRockSelected)
                {
                    Debug.Log("ground rock deselected");
                    _groundRockOne.deselectRock();
                    groundRockSelected = false;
                }
            }
        }
    }


}
