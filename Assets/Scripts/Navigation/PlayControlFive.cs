using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControlFive : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Material normalColor;
    public Material highlightColor;

    public void start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void setPlayer()
    {
        Debug.Log("Entered SetPlayer");
        GetComponent<Renderer>().material = highlightColor;
    }

    public void deselectPlayer()
    {
        Debug.Log("deselect Player");
        GetComponent<Renderer>().material = normalColor;
    }

    public void movePlayer(RaycastHit destinationHit)
    {
        navMeshAgent.destination = destinationHit.point;
        navMeshAgent.Resume();
    }
}
