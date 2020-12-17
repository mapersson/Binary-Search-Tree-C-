using System;
namespace Trees
{
    public class Node
    {
        public int data { get; set; }
        public int height { get; set; }
        private Node _left;
        private Node _right;
        /// <summary>
        /// Property accessor for left child node
        /// When child node is set, the height of the node is updated.
        /// </summary>
        /// <value>Node</value>
        public Node Left
        {
            get { return _left; }
            set
            {
                _left = value;
                this.updateHeight();
            }
        }
        /// <summary>
        /// Property accessor for right child node
        /// When child node is set, the height of the node is updated.
        /// </summary>
        /// <value>Node</value>

        public Node Right
        {
            get { return _right; }
            set
            {
                _right = value;
                this.updateHeight();
            }
        }

        public Node()
        {
            this.height = 1;
        }
        /// <summary>
        /// Create a node with a given integer value.
        /// A node always starts with a height of "1"
        /// </summary>
        /// <param name="data">An integer representing the value of the node</param>
        public Node(int data)
        {
            this.data = data;
            this.height = 1;
            this._left = null;
            this._right = null;
        }

        /// <summary>
        /// Updates the hieght of the node
        /// </summary>
        public void updateHeight()
        {
            this.height = nodeHeight(this);
        }

        /// <summary>
        /// Calculates the balance of the node.
        /// </summary>
        /// <returns>An integer representing the current balance of the node</returns>
        public int balance()
        {
            if (_left == null && _right == null)
            {
                return 0;
            }
            else if (_left == null)
            {
                return 0 - _right.height;
            }
            else if (_right == null)
            {
                return _left.height;
            }
            else
            {
                return _left.height - _right.height;
            }
        }

        /// <summary>
        /// Calculates the height of the provided node. The bottom node has a height of 1, not 0.
        /// </summary>
        /// <param name="n">The node who's height is of interest</param>
        /// <returns>An integer value representing the height of the node</returns>
        protected int nodeHeight(Node n)
        {
            if (n == null)
            {
                return 0;
            }
            return 1 + Math.Max(nodeHeight(n._left), nodeHeight(n._right));
        }
    }
}