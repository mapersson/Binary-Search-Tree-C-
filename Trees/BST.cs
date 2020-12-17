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

        /// <summary>
        /// Insert new value in the tree.
        /// </summary>
        /// <param name="value">The integer value to be inserted into the tree</param>
        public void insertValue(int value)
        {
            root = insertNode(value, root);
        }

        /// <summary>
        /// Inserts a node into the tree.
        /// Function is called recursively until the appropriate insert location is found.
        /// </summary>
        /// <param name="value">An integer value. Can not be a duplicate of a number already inserted.</param>
        /// <param name="cNode">The current node to compare the insert value to.</param>
        /// <returns>A node containing the insert value.</returns>
        protected Node insertNode(int value, Node cNode)
        {
            if (cNode == null)
            {
                cNode = new Node()
                {
                    data = value
                };
                return cNode;
            }
            else if (value > cNode.data)
            {
                cNode.right = insertNode(value, cNode.right);
            }
            else if (value < cNode.data)
            {
                cNode.left = insertNode(value, cNode.left);
            }
            return cNode;
        }

        /// <summary>
        /// Delete a value in the tree.
        /// </summary>
        /// <param name="value">The integer value to be deleted.</param>
        public void deleteValue(int value)
        {
            root = deleteNode(value, root);
        }

        /// <summary>
        /// Deletes the provided value.
        /// </summary>
        /// <param name="value">The value to be deleted</param>
        /// <param name="cNode">The current root node in the subtree.</param>
        /// <returns>The root node of the subtree.</returns>
        protected Node deleteNode(int value, Node cNode)
        {
            if (cNode == null)
            {
                return cNode;
            }
            else if (cNode.data < value)
            {
                cNode.right = deleteNode(value, cNode.right);
            }
            else if (cNode.data > value)
            {
                cNode.left = deleteNode(value, cNode.left);
            }
            else
            {
                if (cNode.left != null && cNode.right != null)
                {
                    cNode.data = minNodeValue(cNode.right);
                    cNode.right = deleteNode(cNode.data, cNode.right);
                    return cNode;
                }
                else if (cNode.left != null)
                {
                    return cNode.left;

                }
                else if (cNode.right != null)
                {
                    return cNode.right;
                }
                else
                {
                    return null;
                }
            }
            return cNode;
        }
        /// <summary>
        /// THe minimum value in the subtree
        /// </summary>
        /// <param name="cNode">The root node of the subtree</param>
        /// <returns>An integer value representing the minimum value in the subtree.</returns>
        protected int minNodeValue(Node cNode)
        {
            int min = cNode.data;
            while (cNode.left != null)
            {
                min = cNode.left.data;
                cNode = cNode.left;
            }
            return min;
        }
        /// <summary>
        /// Searches for the provided value in the tree.
        /// </summary>
        /// <param name="value">The value being searched for</param>
        /// <returns>If the value is value, the value. If the value is not found returns "-1"</returns>
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

        /// <summary>
        /// Searches for the provided value in the subtree.
        /// </summary>
        /// <param name="value">The value being seached for</param>
        /// <param name="n">The root node of the subtree.</param>
        /// <returns>The node containing provided value. If the value is not found, returns null.</returns>
        protected Node searchUtil(int value, Node n)
        {

            if (n == null || value == n.data)
            {
                return n;
            }
            else if (value > n.data)
            {
                return searchUtil(value, n.right);
            }
            else
            {
                return searchUtil(value, n.left);
            }
        }

        /// <summary>
        /// Prints the tree to the consule in preorder transversal order.
        /// If the tree is empty prints the tree is empty. 
        /// </summary>
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

        /// <summary>
        /// Returns the heigh of the tree.
        /// </summary>
        /// <returns>An integer value representing the heigh of the tree.</returns>
        public int height()
        {
            return nodeHeight(root);
        }
        /// <summary>
        /// Prints the value of the nodes in the tree in preoder transersal order.
        /// </summary>
        /// <param name="n">The node who's value is to be printed</param>
        private void print(Node n)
        {
            // TODO: Refactor to a single null check. 
            Console.Write(" Value:{0}", n.data);
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
            //TODO: Move this out of the function, and to the calling function.
            n.height = 1 + Math.Max(nodeHeight(n.left), nodeHeight(n.right));
            return n.height;
        }

        /// <summary>
        /// A test to confirm the tree is infact a Binary Search Tree.
        /// </summary>
        /// <returns>A boolean, true if the tree is a BST, false if the tree is not a BST</returns>
        public bool isBST()
        {
            return isBSTUtil(root, int.MinValue, int.MaxValue);
        }

        /// <summary>
        /// Tests that the subtrees below do not contain values higher or lower than their parent.
        /// </summary>
        /// <param name="n">The current node</param>
        /// <param name="min">The current min value of the parent tree</param>
        /// <param name="max">The current max value of the parent tree</param>
        /// <returns>A boolean, true if the tree is a BST, false if the tree is not a BST</returns>
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


}