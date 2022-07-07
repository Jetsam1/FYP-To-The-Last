
using System.Collections.Generic;

namespace BehaviourTree
{


    public class Sequence : Node
    {
        public Sequence(): base() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Eval()
        {
            bool isRunning = false;

            foreach(Node node in children )
            {
                switch (node.Eval())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        isRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            state = isRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }
    

    public class Selector :Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }

        public override NodeState Eval()
        {
            foreach (Node node in children)
            {
                switch (node.Eval())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}
