using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class AttackNode : Node
{

    private Transform lastTarget;
    private HealthBar enemyManager;

    private float attackTime = 1f;
    private float attackCounter = 0f;

    public AttackNode()
    {
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != lastTarget)
        {
            enemyManager = target.GetComponentInChildren<HealthBar>();
            lastTarget = target;
        }

        attackCounter += Time.deltaTime;
        if (attackCounter >= attackTime)
        {
            enemyManager.GetHit();
            attackCounter = 0f;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
