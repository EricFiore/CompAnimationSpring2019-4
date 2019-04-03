using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeSharpPlus;
using System;

public class BehaviorScriptThree : MonoBehaviour
{
    public Transform wanderOne;
    public Transform wanderTwo;
    public Transform wanderThree;
    public Transform wanderFour;
    public BehaviorAgent behaviorAgent;
    public GameObject participant;
    public GameObject trafficLight;
    public IsVisible _isVisible;

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

    }

    
    public bool getObjectColor()
    {
        Debug.Log(_isVisible.getColor());
        return (_isVisible.getColor());
    }

    protected Node ST_ApproachAndWait(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(participant.GetComponent<BehaviorMecanim>().Node_GoToUpToRadius(position, 2.0f), new LeafWait(500));
    }

    protected Node BuildTreeRoot()
    {
        Func<bool> act = () => _isVisible.getColor();
        Node roaming = new DecoratorLoop(
                        new SequenceShuffle(
                        this.ST_ApproachAndWait(this.wanderOne),
                        this.ST_ApproachAndWait(this.wanderTwo),
                        this.ST_ApproachAndWait(this.wanderThree),
                        this.ST_ApproachAndWait(this.wanderFour)));
        Node Action = new Sequence(participant.GetComponent<BehaviorMecanim>().Node_HandAnimation("CROWDPUMP", true), new LeafWait(1000));
        //Node Trigger = new DecoratorLoop(new LeafAssert(act));
        Node sequenceNodes = new Sequence (new LeafAssert(act), roaming);
        Node selectingNode = new DecoratorLoop(new Selector(sequenceNodes, Action));
        return selectingNode;
    }
}
