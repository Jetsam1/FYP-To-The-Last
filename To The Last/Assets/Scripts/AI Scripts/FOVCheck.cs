using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class FOVCheck : Node
{

    private Transform transform;
    private static int enemyLayerMask = 1 << 6;
    public FOVCheck(Transform T)
    {
        transform = T;
    }

    public override NodeState Eval()
    {
        object o = getData("target");
        if(o==null)
        {
            Collider[] col = Physics.OverlapSphere(transform.position, AI.FOVrange, enemyLayerMask);
            Debug.Log(col.Length);

            if(col.Length>0)
            {
                parent.setData("target", col[0].transform); //defines target to the object
                state = NodeState.SUCCESS;
                return state;
            }
        }
        state = NodeState.FAILURE;
        return state;
    }
}
