using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class MoveToTargetNode : Node
{
    private Transform currentPos;

    public MoveToTargetNode(Transform currentPos)
    {
        this.currentPos = currentPos;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(currentPos.position, target.position) > 0.01f)
        {
            currentPos.position = Vector3.MoveTowards(
                currentPos.position, target.position, ZombieTree.speed * Time.deltaTime);
            Vector2 moveDirection = (target.position - currentPos.position).normalized;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            currentPos.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        state = NodeState.RUNNING;
        return state;
    }
}
