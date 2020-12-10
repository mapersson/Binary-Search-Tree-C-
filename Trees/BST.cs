using System;

namespace Trees
{
    public class BST
    {
        Node root;

        public BST()
        {

        }
        public BST(Node root)
        {
            this.root = root;
        }

        public bool insertNode(Node newNode)
        {
            if (root == null)
            {
                root = newNode;
                return true;
            }
            else
            {
                Node cnode = root;
                while (cnode != null) //This is defensive. Code should never provde a null cnode at this point. 
                {
                    if (newNode.data > cnode.data)
                    {
                        if (cnode.right != null)
                        {
                            cnode = cnode.right;
                        }
                        else
                        {
                            cnode.right = newNode;
                            return true;
                        }
                    }
                    else
                    {
                        if (cnode.left != null)
                        {
                            cnode = cnode.left;
                        }
                        else
                        {
                            cnode.left = newNode;
                            return true;
                        }
                    }
                }
                return false; // If insert fails return false. 
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

        private int nodeHeight(Node n)
        {
            if (n == null)
            {
                return -1;
            }
            n.height = 1 + Math.Max(nodeHeight(n.left), nodeHeight(n.right));
            return n.height;
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