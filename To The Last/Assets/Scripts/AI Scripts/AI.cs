using System.Collections;
using System.Collections.Generic;

using BehaviourTree;


public class AI : Tree
{

    public EnemyManager manager;
    // Start is called before the first frame update
    public UnityEngine.Transform[] path;
    
    static public float speed = 5f;
    static public float FOVrange = 15.0f;
    protected override Node SetupTree()
    {
         Node root = new Selector(new List<Node>
         {
             new Sequence(new List<Node>
             { 
                  new FOVCheck(transform),
                  new GoToPlayer(transform),

             }),
             new Patrol(transform,path),


     });
       

       // Node root = new Sequence(new List<Node>
       // {
       //     new FOVCheck(transform),
       //     new GoToPlayer(transform),
       // });
        return root;
    }
}
