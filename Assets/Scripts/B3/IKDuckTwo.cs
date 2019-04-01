using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IKDuckTwo : MonoBehaviour
{
    #region Data
    [SerializeField]
    Transform hand;
    [SerializeField]
    Transform otherGuyChest;
    [SerializeField]
    Transform sword;
    [SerializeField]
    Transform CheckPointTwo;

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
        if (animator.GetInteger("condition") == 2)
        {
            Vector3 targetPosition = otherGuyChestPosition;

            animator.SetIKPosition(AvatarIKGoal.LeftHand, targetPosition);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.25f);
            animator.SetInteger("condition", 0);
        }
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
        otherGuyChestPosition = otherGuyChest.position;
        swordPosition = sword.position;

        float distanceToOtherPlayer = Vector3.Distance(otherGuyChestPosition, hand.position);
        float distanceToSword = Vector3.Distance(swordPosition, hand.position);
        float distanceToCheckTwo = Vector3.Distance(CheckPointTwo.position, hand.position);
        Debug.Log(distanceToSword);
        if (distanceToOtherPlayer < 1.5f)
        {
            animator.SetInteger("condition", 2);
        }
        if (distanceToSword < 1.5f)
        {
            animator.SetInteger("condition", 1);
        }
        if (distanceToOtherPlayer < 2.0f && distanceToSword < 1.5f)
        {
            animator.SetInteger("condition", 1);
        }
        if (distanceToCheckTwo < 2.0f)
        {
            animator.SetInteger("condition", 0);
        }
    }
}

