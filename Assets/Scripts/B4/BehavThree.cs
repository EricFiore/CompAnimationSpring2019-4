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
    
    private int gameStage;

    // Start is called before the first frame update
    void Start()
    {
        gameStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToHeroOne = Vector3.Distance(participant.transform.position, heroOne.transform.position);
        float distanceToHeroTwo = Vector3.Distance(participant.transform.position, heroTwo.transform.position);

        if (distanceToHeroOne < 2.0f && gameStage == 0)
        {
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
            gameStage++;
        }
        else if(distanceToHeroTwo < 2.0f && gameStage == 0)
        {
            behaviorAgent = new BehaviorAgent(this.BuildTreeRoot());
            BehaviorManager.Instance.Register(behaviorAgent);
            behaviorAgent.StartBehavior();
            gameStage++;
        }

    }

    protected Node ST_ApproachAndWait(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoToUpToRadius(position, 2.0f), new LeafWait(500));
    }

    protected Node BuildTreeRoot()
    {
            Node roaming = new Sequence(
                    (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("HANDSUP", true)),
                    (new LeafWait(1000)));
            return roaming;
    }
}
