using System.Collections;
using System.Collections.Generic;


namespace BehaviourTree
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (Node child in children)
                Attach(child);

        }

        private void Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Eval() => NodeState.FAILURE;

        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        public void setData(string key, object val)
        {
            dataContext[key] = val;
        }

        public object getData(string key)
        {
            object val = null;
            if (dataContext.TryGetValue(key, out val))
                return val;

            Node node = parent;
            while (node != null)
            {
                val = node.getData(key);
                if (val != null)
                    return val;
                node = node.parent;
            }
            return null;
        }

        public bool clearData(string key)
        {
            if (dataContext.ContainsKey(key))
            {
                dataContext.Remove(key);
                return true;

            }
            Node node = parent;
            while (node != null)
            {
                bool cleared = node.clearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;
        }

    }
}

