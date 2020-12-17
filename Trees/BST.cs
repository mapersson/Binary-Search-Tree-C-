using System;
using System.Text;
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
                cNode.updateHeight();
                return cNode;
            }
            else if (value > cNode.data)
            {
                cNode.Right = insertNode(value, cNode.Right);
            }
            else if (value < cNode.data)
            {
                cNode.Left = insertNode(value, cNode.Left);
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
                cNode.Right = deleteNode(value, cNode.Right);
            }
            else if (cNode.data > value)
            {
                cNode.Left = deleteNode(value, cNode.Left);
            }
            else
            {
                if (cNode.Left != null && cNode.Right != null)
                {
                    cNode.data = minNodeValue(cNode.Right);
                    cNode.Right = deleteNode(cNode.data, cNode.Right);
                    return cNode;
                }
                else if (cNode.Left != null)
                {
                    return cNode.Left;

                }
                else if (cNode.Right != null)
                {
                    return cNode.Right;
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
            while (cNode.Left != null)
            {
                min = cNode.Left.data;
                cNode = cNode.Left;
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
                return searchUtil(value, n.Right);
            }
            else
            {
                return searchUtil(value, n.Left);
            }
        }

        /// <summary>
        /// Prints the tree to the consule in preorder transversal order.
        /// If the tree is empty prints the tree is empty. 
        /// </summary>
        public string printTree()
        {
            if (root == null)
            {
                return "Empty Tree";
            }
            else
            {
                return preorder(root, "");
            }
        }

        /// <summary>
        /// Returns the heigh of the tree.
        /// </summary>
        /// <returns>An integer value representing the heigh of the tree.</returns>
        public int height()
        {
            root.updateHeight();
            return root.height;
        }

        private String preorder(Node n, String output)
        {
            if (n != null)
            {
                output = output + " " + n.data.ToString() + preorder(n.Left, output) + preorder(n.Right, output);
                return output;
            }

            return output;
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

            return isBSTUtil(n.Left, min, n.data) && isBSTUtil(n.Right, n.data, max);
        }
    }


}