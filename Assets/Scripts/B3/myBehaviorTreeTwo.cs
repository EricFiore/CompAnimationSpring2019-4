using System;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TreeSharpPlus;

public class myBehaviorTreeTwo : MonoBehaviour
{
    public Transform wanderOne;
    public Transform wanderTwo;
    public Transform wanderThree;
    public GameObject participant;
    public GameObject participantTwo;
    public GameObject participantThree;

    public BehaviorAgent behaviorAgent;

    private int loopCount = 0;

    void Start()
    {
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
    }


    protected Node ST_ApproachAndWait(Transform target, GameObject participant)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoToUpToRadius(position, 2.0f), new LeafWait(500));
    }

    protected Node BuildTreeRoot()
    {
        String actionOne, actionTwo, actionThree, actionFour, actionFive;
        float randNum = UnityEngine.Random.Range(1.0f, 3.0f);
        if (randNum >= 2.0f)
        {
            actionOne = "DUCK";
            actionTwo = "STEPBACK";
            actionThree = "SURPRISED";
            actionFour = "SATNIGHTFEVER";
            actionFive = "HANDSUP";
        }
        else
        {
            actionOne = "STEPBACK";
            actionTwo = "DUCK";
            actionThree = "SATNIGHTFEVER";
            actionFour = "SURPRISED";
            actionFive = "HANDSUP";
        }
        Debug.Log("action one is " + actionOne + "action two is " + actionTwo);
        Node roaming = new Sequence(
                    new SequenceParallel(
                        this.ST_ApproachAndWait(this.wanderOne, participant),
                        this.ST_ApproachAndWait(this.wanderOne, participantTwo),
                        this.ST_ApproachAndWait(this.wanderOne, participantThree)),
                        new Sequence(
                        (participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation(actionOne, true)),
                        (participantTwo.GetComponent<BehaviorMecanim>().Node_BodyAnimation(actionTwo, true)),
                        (participantThree.GetComponent<BehaviorMecanim>().Node_HandAnimation(actionFive, true)),
                        (new LeafWait(1000))),
                        new Sequence(
                        (participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation(actionOne, false)),
                        (participantTwo.GetComponent<BehaviorMecanim>().Node_BodyAnimation(actionTwo, false)),
                        (participantThree.GetComponent<BehaviorMecanim>().Node_HandAnimation(actionFive, false)),
                        (new LeafWait(1000))),
                    new SequenceParallel(
                        this.ST_ApproachAndWait(this.wanderTwo, participant),
                        this.ST_ApproachAndWait(this.wanderTwo, participantTwo),
                        this.ST_ApproachAndWait(this.wanderTwo, participantThree)),
                        new Sequence(
                        (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(actionThree, true)),
                        (participantTwo.GetComponent<BehaviorMecanim>().Node_HandAnimation(actionFour, true)),
                        (participantThree.GetComponent<BehaviorMecanim>().Node_HandAnimation(actionFive, true)),
                        (new LeafWait(1000))),
                        new Sequence(
                        (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation(actionFour, false)),
                        (participantTwo.GetComponent<BehaviorMecanim>().Node_HandAnimation(actionThree, false)),
                        (participantThree.GetComponent<BehaviorMecanim>().Node_HandAnimation(actionFive, false)),
                        (new LeafWait(1000))),
                    new SequenceParallel(
                        this.ST_ApproachAndWait(this.wanderThree, participant),
                        this.ST_ApproachAndWait(this.wanderThree, participantTwo),
                        this.ST_ApproachAndWait(this.wanderThree, participantThree)));

        return roaming;
    }
}
