using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class Tree : MonoBehaviour
    {

        private Node root = null;
        // Start is called before the first frame update
        protected void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }

        protected abstract Node SetupTree();
    }
}
