
using System.Collections.Generic;
using BehaviourTree;

enemyType type;
public class AI : Tree
{

    enemyType type;
    // Start is called before the first frame update
    public UnityEngine.Transform[] path;
    static public float speed = 5;  
    protected override Node SetupTree()
    {
        Node root = new Patrol(transform, path);
        return root;
    }
}
