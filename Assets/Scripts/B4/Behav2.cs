using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeSharpPlus;
using System;

public class Behav2: MonoBehaviour
{
	public Transform wanderOne;
    public Transform wanderTwo;
    public Transform wanderThree;
    public BehaviorAgent behaviorAgent;
    public GameObject participant;
    public GameObject enemy;
    public GameObject cubeOne;
    public GameObject cubeTwo;
    public GameObject cubeThree;
    public GameObject sword;
    bool isChosen = false;
    private bool finalStage;
    TwoHeroController _test;

    private int gameStage;
    private bool deadSword;

    // Start is called before the first frame update
    void Start()
    {
        deadSword = false;
        finalStage = false;
        gameStage = 0;
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
    }

    // Update is called once per frame
    void Update()
    {
        if (wanderOne.name == "arrived" && gameStage == 0)
        {
            behaviorAgent.StopBehavior();
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
            wanderOne.name = "afterArrive in behav2";
            gameStage++;
        }

        if (sword.name == "deadSword" && !deadSword)
        {
            deadSword = true;
            behaviorAgent.StopBehavior();
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
        }

        if (participant.name == "chosen")
		{
            isChosen = true;
		}
		else
		{
            isChosen = false;
            float distanceToBox = Vector3.Distance(participant.transform.position, wanderOne.position);
            if (distanceToBox < 1.8f)
            {
                if (cubeOne.tag == "pickup")
                {
                    participant.transform.LookAt(cubeOne.transform);
                }
                else if (cubeOne.tag == "dead" && cubeTwo.tag == "pickup")
                {
                    participant.transform.LookAt(cubeTwo.transform);
                }
                else
                {
                    participant.transform.LookAt(cubeThree.transform);
                }
            }
        }

        if (enemy.name == "coward" && !finalStage)
        {
            finalStage = true;
            behaviorAgent.StopBehavior();
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
        }

        if (isChosen == true)
        {
            behaviorAgent.StopBehavior();
        }
        else
        {
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
        if (wanderOne.name != "arrived")
        {
            if (isChosen == false)
            {
                Node roaming = new DecoratorLoop(
                    new Sequence(
                        this.ST_ApproachAndWait(this.wanderOne),
                        (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("POINTING", true)),
						(new LeafWait(500)),
						(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("POINTING", false)),
                        (new LeafWait(1000))));
                return roaming;
            }
            else
            {
                Node roaming = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("FIGHT", true), new LeafWait(1000));
                return roaming;
            }
        }
        else if (finalStage && !deadSword)
        {
            Node roaming = new DecoratorLoop(
                new Sequence(
                       this.ST_ApproachAndWait(this.wanderThree),
                       (new LeafWait(1000))));
            return roaming;
        }
        else if (deadSword)
        {
            Node roaming = new DecoratorLoop(
                new Sequence(
                       this.ST_ApproachAndWait(this.wanderOne),
                       (new LeafWait(1000))));
            return roaming;
        }
        else
        {
            Node roaming = new DecoratorLoop(
                new Sequence(
                        this.ST_ApproachAndWait(this.wanderTwo),
                        (new LeafWait(1000))));
            return roaming;
        }
    }
}