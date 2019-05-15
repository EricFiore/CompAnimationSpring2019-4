using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeSharpPlus;
using System;

public class BehavThree : MonoBehaviour
{
    public BehaviorAgent behaviorAgent;
    public GameObject participant;
    public GameObject heroOne;
    public GameObject heroTwo;
    public Transform wanderOne;

    private float distanceToGoal;
    private int gameStage;
    private int num;
    private bool finalAnimOne;
    private bool finalAnimTwo;

    // Start is called before the first frame update
    void Start()
    {
        gameStage = 0;
        finalAnimOne = false;
        finalAnimTwo = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToHeroOne = Vector3.Distance(participant.transform.position, heroOne.transform.position);
        float distanceToHeroTwo = Vector3.Distance(participant.transform.position, heroTwo.transform.position);
        distanceToGoal = Vector3.Distance(participant.transform.position, wanderOne.position);

        if (distanceToHeroOne < 2.0f && distanceToHeroTwo < 2.0f && gameStage != 3)
        {
            num = UnityEngine.Random.Range(1, 8);
            gameStage = 3;
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
        }

        if (distanceToHeroOne < 2.0f && gameStage == 0 && gameStage != 3 && gameStage != 2)
        {
            num = UnityEngine.Random.Range(1, 8);
            gameStage = 2;
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
        }
        else if(distanceToHeroTwo < 2.0f && gameStage == 0 && gameStage != 3 && gameStage != 2)
        {
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
        }
        if (distanceToGoal < 2.0f && distanceToHeroOne < 2.0f && finalAnimOne == false)
        {
            finalAnimOne = true;
            behaviorAgent.StopBehavior();
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
        }
    }


    protected Node ST_ApproachAndWait(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoToUpToRadius(position, 2.0f), new LeafWait(500));
    }

    protected Node BuildTreeRoot()
    {
        if (gameStage == 3 && num > 4 && !finalAnimOne && !finalAnimTwo)
        {
            Node roaming = new Sequence(
                    (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("HANDSUP", true)),
                    (new LeafWait(1000)));
            participant.name = "coward";
            return roaming;
        }
        else if (gameStage == 3 && num <= 4 && !finalAnimOne && !finalAnimTwo)
        {
            Node roaming = new Sequence(
                    this.ST_ApproachAndWait(this.wanderOne),
                    (new LeafWait(1000)));
            participant.name = "coward";
            return roaming;
        }
        else if (gameStage == 2 && num > 4 && !finalAnimOne && !finalAnimTwo)
        {
            Node roaming = new Sequence(
                    (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("STAYAWAY", true)),
                    (new LeafWait(500)));
            return roaming;
        }
        else if (gameStage == 2 && num <= 4 && !finalAnimOne && !finalAnimTwo)
        {
            Node roaming = new Sequence(
                    (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("SURPRISED", true)),
                    (new LeafWait(1000)));
            return roaming;
        }
        else if (finalAnimOne == true && !finalAnimTwo)
        {
            Node roaming = new Sequence(
                    (participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("DUCK", true)),
                    (new LeafWait(1000)));
            return roaming;
        }
        else
        {
            Node roaming = new Sequence(
                    (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("BEINGCOCKY", true)),
                    (new LeafWait(1000)));
            return roaming;
        }
    }
}
