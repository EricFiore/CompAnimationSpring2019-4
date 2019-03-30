using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateLaterallyOther : MonoBehaviour
{
    private float beginTime;
    private float lengthOfMovement;
    private bool atEnd;
    private float initialZPostion;              //to keep track of the initial z position
    private float finalZPosition;               //to keep track of the starting z position
    private Vector3 staticEndPosition;        //this keeps track of the end position
    private Vector3 staticStartPosition;      //this keeps track of the start position
    public float speed;
    public Transform startPosition;             //the starting position object (same as obstacle that is moving
    public Transform endPosition;               //the end position object that obstacle will move towards

    void Start()
    {
        beginTime = Time.time;
        atEnd = false;
        initialZPostion = startPosition.position.z;
        finalZPosition = endPosition.position.z;
        staticStartPosition = startPosition.position;           //mark start obstacle position
        staticEndPosition = endPosition.position;               //mark end position
        lengthOfMovement = Vector3.Distance(startPosition.position, endPosition.position);
        Debug.Log("lengthOfMovement is " + lengthOfMovement + " begin time is " + beginTime);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceObjectMoved = (Time.time - beginTime) * speed;
        float percentageMovementCompleted = distanceObjectMoved / lengthOfMovement;
        if (!atEnd)
        {
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, percentageMovementCompleted);
            if (transform.position.z <= finalZPosition + 0.001)
            {
                atEnd = true;
                endPosition.position = staticStartPosition;           //move end goal object to starting position so obstacle will follow back
                beginTime = Time.time;
            }
        }
        else if (atEnd)
        {
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, percentageMovementCompleted);
            if (transform.position.z >= initialZPostion - 0.001)
            {
                atEnd = false;
                endPosition.position = staticEndPosition;
                beginTime = Time.time;
            }
        }
    }
}
