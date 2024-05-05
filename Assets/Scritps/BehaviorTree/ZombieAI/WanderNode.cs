using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class WanderNode : Node
{
    private Transform currentPos;

    private float waitTime = 2f; // in seconds
    private float waitCounter = 0f;
    private bool waiting = false;

    private Vector3 target;
    private float radius = 3f;
    
    public WanderNode(Transform currentPos)
    {
        this.currentPos = currentPos;
        target = currentPos.position;
    }
    public override NodeState Evaluate()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                waiting = false;
            }
        }
        else
        {
            if (Vector3.Distance(currentPos.position, target) < 0.01f)
            {
                currentPos.position = target;
                waitCounter = 0f;
                waiting = true;

                Vector2 random = Random.insideUnitCircle * radius * 0.5f;
                target = new Vector3(currentPos.position.x, currentPos.position.y) + new Vector3(random.x, random.y);
                Vector2 moveDirection = (target - currentPos.position).normalized;
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                currentPos.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
            else
            {
                currentPos.position = Vector3.MoveTowards(currentPos.position, target, ZombieTree.speed * Time.deltaTime);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
