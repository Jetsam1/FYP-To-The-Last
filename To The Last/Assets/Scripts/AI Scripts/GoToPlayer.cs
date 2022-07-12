using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class GoToPlayer : Node
{
    private Transform transform;

    public GoToPlayer(Transform T)
    {
        transform = T;
    }

    public override NodeState Eval()
    {
        Transform target = (Transform)getData("target");

        if (Vector3.Distance(transform.position, target.position) > 0.0001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, AI.speed * Time.deltaTime);
            transform.LookAt(target.position);
            Debug.Log(transform.position);
        }
        state = NodeState.RUNNING;
        return state;
    }

}
