using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeSharpPlus;
using System;

public class BackgroundCompanionOne : MonoBehaviour
{
    public BehaviorAgent behaviorAgent;
    public GameObject participant;
    public GameObject cube;

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
        participant.transform.LookAt(cube.transform);
    }

    protected Node BuildTreeRoot()
    {
        Node roaming = new DecoratorLoop(
                    new Sequence(
                        (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("CLAP", true)),
                        (participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("CRY", true))));

        return roaming;
    }
}
