using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeSharpPlus;
using System;

public class Behav2: MonoBehaviour
{
	public Transform wanderOne;
    public BehaviorAgent behaviorAgent;
    public GameObject participant;
    bool isRed = false;
    TwoHeroController _test;


    // Start is called before the first frame update
    void Start()
    {
        behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(behaviorAgent);
        behaviorAgent.StartBehavior();
    }

    // Update is called once per frame
    void Update()
    {
		if(participant.name == "chosen")
		{
			isRed = true;
		}
		else
		{
			isRed = false;
		}

        if (isRed == true)
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
        if(isRed == false)
		{
			Node roaming = new DecoratorLoop(
							new SequenceShuffle(
							this.ST_ApproachAndWait(this.wanderOne)
							));
							return roaming;
		}
		
		else
		{
			Node roaming = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_BodyAnimation("FIGHT", true), new LeafWait(1000));
			return roaming;
		}

        
    }
}