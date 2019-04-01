using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IKDuckThree : MonoBehaviour
{
    #region Data
    [SerializeField]
    Transform sword;
    [SerializeField]
    Transform hand;

    static readonly Vector3 offset = new Vector3(0.02f, 0.04f, 0);

    Vector3 otherGuyChestPosition;
    Vector3 swordPosition;

    Animator animator;
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("condition", 0);

    }

    public void OnAnimatorIK()
    {
        if (animator.GetInteger("condition") == 1)
        {
            Vector3 targetPosition = swordPosition;

            animator.SetIKPosition(AvatarIKGoal.RightHand, targetPosition);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.40f);
            animator.SetInteger("condition", 0);
        }
    }

    void LateUpdate()
    {
        swordPosition = sword.position;

        float distanceToSword = Vector3.Distance(swordPosition, hand.position);
        Debug.Log(distanceToSword);
        if (distanceToSword < 1.5f)
        {
            animator.SetInteger("condition", 1);
        }
    }
}


