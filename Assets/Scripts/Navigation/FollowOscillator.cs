using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOscillator : MonoBehaviour
{
    private float beginTime;
    private float lengthOfMovement;
    public float speed;
    public float lerpFraction;
    public Transform startPosition;             //the starting position object (same as obstacle that is moving
    public Transform endPosition;               //the end position object that obstacle will move towards

    void Start()
    {
        beginTime = Time.time;
        lengthOfMovement = Vector3.Distance(startPosition.position, endPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceObjectMoved = (Time.time - beginTime) * speed;
        float percentageMovementCompleted = distanceObjectMoved / lengthOfMovement;
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, lerpFraction);
    }
}
