using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class ZombieTree : AITree
{
    public static float speed = 2f;
    public static float sightRange = 5f;
    public static float attackRange = 1f;
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckInAttackRangeNode(transform),
                new AttackNode()
            }),
            new Sequence(new List<Node>
            {
                new CheckInSightNode(transform),
                new MoveToTargetNode(transform)
            }),
            new WanderNode(transform) 
        });

        return root;
    }
}
