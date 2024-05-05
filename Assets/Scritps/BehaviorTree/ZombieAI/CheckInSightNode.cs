using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckInSightNode : Node
{
    private static int enemyLayerMask = 1 << 6;
    private Transform currentPos;

    public CheckInSightNode(Transform currentPos)
    {
        this.currentPos = currentPos;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(currentPos.position.x, currentPos.position.y), ZombieTree.sightRange, enemyLayerMask);

            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }

        else
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(currentPos.position.x, currentPos.position.y), ZombieTree.sightRange, enemyLayerMask);
            if (colliders.Length == 0)
            {
                state = NodeState.FAILURE;
                return state;
            }
            state = NodeState.SUCCESS;
            return state;
        }
    }
}
