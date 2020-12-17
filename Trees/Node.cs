using System;
namespace Trees
{
    public class Node
    {
        public int data { get; set; }
        public int height { get; set; }
        private Node _left;
        private Node _right;
        public Node Left
        {
            get { return _left; }
            set
            {
                _left = value;
                this.updateHeight();
            }
        }
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

        }
        public Node(int data)
        {
            this.data = data;
            this.height = 1;
            this._left = null;
            this._right = null;
        }

        public void updateHeight()
        {
            this.height = nodeHeight(this);
        }

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