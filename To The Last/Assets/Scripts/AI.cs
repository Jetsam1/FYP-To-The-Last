
using System.Collections.Generic;
using BehaviourTree;

public class AI : Tree
{
    // Start is called before the first frame update
    public UnityEngine.Transform[] path;

    public static float speed = 1.5f;

    protected override Node SetupTree()
    {
        Node root = new Patrol(transform, path);
        return root;
    }
}
