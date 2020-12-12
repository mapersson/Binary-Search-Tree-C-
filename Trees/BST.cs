using System;

namespace Trees
{
    public class BST
    {
        protected Node root;

        public BST()
        {

        }
        public BST(Node root)
        {
            this.root = root;
        }

        public void insertNode(int value)
        {
            root = insertNode(value, root);
        }

        private Node insertNode(int value, Node cNode)
        {
            if (cNode == null)
            {
                cNode = new Node()
                {
                    data = value
                };
                return cNode;
            }
            if (value > cNode.data)
            {
                cNode.right = insertNode(value, cNode.right);
            }
            if (value < cNode.data)
            {
                cNode.left = insertNode(value, cNode.left);
            }
            return cNode;
        }

        public int search(int value)
        {
            Node foundNode = searchUtil(value, root);
            if (foundNode != null)
            {
                return foundNode.data;
            }
            else
            {
                return -1;
            }
        }

        protected Node searchUtil(int value, Node n)
        {
            // TODO: Clean up the null check in this method. 
            if (n == null)
            {
                return null;
            }
            else if (value == n.data)
            {
                return n;
            }
            else if (value > n.data)
            {
                return searchUtil(value, n.right);
            }
            else if (value < n.data)
            {
                return searchUtil(value, n.left);
            }
            else
            {
                return null;
            }
        }

        public void printTree()
        {
            if (root == null)
            {
                Console.WriteLine("Empty Tree");
            }
            else
            {
                Node cnode = root;
                print(cnode);
            }
        }

        public int height()
        {
            return nodeHeight(root);
        }

        private void print(Node n)
        {
            // TODO: Refactor to a single null check. 
            Console.Write(" Value:{0}, Height:{1} ", n.data, n.height);
            if (n.left != null)
            {
                print(n.left);
            }
            if (n.right != null)
            {
                print(n.right);
            }
            return;
        }

        protected int nodeHeight(Node n)
        {
            if (n == null)
            {
                return -1; // Return -1 to account that the root node has a height of 0
            }
            n.height = 1 + Math.Max(nodeHeight(n.left), nodeHeight(n.right));
            return n.height;
        }

        public bool isBST()
        {
            return isBSTUtil(root, int.MinValue, int.MaxValue);
        }

        private bool isBSTUtil(Node n, int min, int max)
        {
            if (n == null)
            {
                return true;
            }
            if (n.data < min || n.data > max)
            {
                return false;
            }

            return isBSTUtil(n.left, min, n.data) && isBSTUtil(n.right, n.data, max);
        }
    }

    public class Node
    {
        public int data { get; set; }
        public int height { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node()
        {

        }
        public Node(int data)
        {
            this.data = data;
            this.height = 0;
            this.left = null;
            this.right = null;
        }
    }
}