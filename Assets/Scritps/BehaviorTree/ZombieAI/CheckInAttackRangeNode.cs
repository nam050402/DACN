using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckInAttackRangeNode : Node
{
    private Transform currentPos;

    public CheckInAttackRangeNode(Transform currentPos)
    {
        this.currentPos = currentPos;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector3.Distance(currentPos.position, target.position) <= ZombieTree.attackRange)
        {

            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
