using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class FOVCheck : Node
{

    private Transform transform;

    public FOVCheck(Transform T)
    {
        transform = T;
    }

    public override NodeState Eval()
    {
        object o = getData("target");
        if(o==null)
        {

        }
        state = NodeState.SUCCESS;
        return state;
    }
}
