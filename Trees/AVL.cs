
using System;

namespace Trees
{

    public class AVL : BST
    {
        public AVL()
        {

        }
        public AVL(Node root)
        {
            this.root = root;
        }
        /// <summary>
        /// Calculates the balance of the current node
        /// </summary>
        /// <param name="ln">The Left hand child node</param>
        /// <param name="rn">The Right hand child node</param>
        /// <returns>The balance of the current node</returns>
        private int balance(Node ln, Node rn)
        {
            return ln.height - rn.height;
        }

        /// <summary>
        /// Insert new value in the tree.
        /// </summary>
        /// <param name="value">The integer value to be inserted into the tree</param>
        public new void insertValue(int value)
        {
            root = insertNode(value, root);
        }

        /// <summary>
        /// Inserts a node into the tree.
        /// Function is called recursively until the appropriate insert location is found.
        /// Also re-balances the tree.
        /// </summary>
        /// <param name="value">An integer value. Can not be a duplicate of a number already inserted.</param>
        /// <param name="cNode">The current node to compare the insert value to.</param>
        /// <returns>A node containing the insert value.</returns>
        private new Node insertNode(int value, Node cNode)
        {

            if (cNode == null)
            {
                cNode = new Node(value);
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

            return rebalance(cNode);
        }

        /// <summary>
        /// Delete a value in the tree.
        /// </summary>
        /// <param name="value">The integer value to be deleted.</param>
        public new void deleteValue(int value)
        {
            root = deleteNode(value, root);
        }

        /// <summary>
        /// Deletes the provided value.
        /// Function is called recursively until the appropriate insert location is found.
        /// Also re-balances the tree.
        /// </summary>
        /// <param name="value">The value to be deleted</param>
        /// <param name="cNode">The current root node in the subtree.</param>
        /// <returns>The root node of the subtree.</returns>
        protected new Node deleteNode(int value, Node cNode)
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
                return null;
            }

            return rebalance(cNode);
        }

        /// <summary>
        /// A test to confirm the tree is infact an AVL Tree.
        /// </summary>
        /// <returns>A boolean, true if the tree is an AVL Tree, false if the tree is not an AVL Tree</returns>
        public bool isAVL()
        {
            if (this.isBST() && this.isAVLUtil(root))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tests that the subtrees below do not contain values higher or lower than their parent.
        /// </summary>
        /// <param name="n">The current node</param>
        /// <param name="min">The current min value of the parent tree</param>
        /// <param name="max">The current max value of the parent tree</param>
        /// <returns>A boolean, true if the tree is an AVL Tree, false if the tree is not an AVL Tree</returns>
        private bool isAVLUtil(Node n)
        {
            if (n == null)
            {
                return true;
            }
            if (n.balance() > 1 || n.balance() < -1)
            {
                return false;
            }
            return isAVLUtil(n.Left) && isAVLUtil(n.Right);
        }
        /// <summary>
        /// Rebalances the substrees of the provded node.
        /// </summary>
        /// <param name="cNode">The root node to be rebalanced</param>
        /// <returns>The root node afert the rebalance has taken place</returns>
        protected Node rebalance(Node cNode)
        {
            var bf = cNode.balance();

            if (bf > 1)
            {
                if (cNode.Left.balance() == 1)
                {
                    cNode = RightRotation(cNode);
                }
                else
                {
                    cNode.Left = LeftRotation(cNode.Left);
                    cNode = RightRotation(cNode);
                }
            }
            else if (bf < -1)
            {
                if (cNode.Right.balance() == -1)
                {
                    cNode = LeftRotation(cNode);
                }
                else
                {
                    cNode.Right = RightRotation(cNode.Right);
                    cNode = LeftRotation(cNode);
                }
            }
            return cNode;
        }
        /// <summary>
        /// Applies a left rotation to the provided node 
        /// </summary>
        /// <param name="n">The node to be rotated about</param>
        /// <returns>A node after the left rotation has been completed.</returns>
        protected Node LeftRotation(Node n)
        {
            Node b = n.Right;
            n.Right = b.Left;
            b.Left = n;
            return b;
        }
        /// <summary>
        /// Applies a right rotation to the provided node 
        /// </summary>
        /// <param name="n">The node to be rotated about</param>
        /// <returns>A node after the right rotation has been completed.</returns>
        protected Node RightRotation(Node n)
        {
            Node b = n.Left;
            n.Left = b.Right;
            b.Right = n;
            return b;
        }
    }
}