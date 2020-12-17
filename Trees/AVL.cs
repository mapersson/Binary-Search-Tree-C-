
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
        /// <param name="ln">The left hand child node</param>
        /// <param name="rn">The right hand child node</param>
        /// <returns>The balance of the current node</returns>
        private int balance(Node ln, Node rn)
        {
            return nodeHeight(ln) - nodeHeight(rn);
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

            var bf = balance(cNode.left, cNode.right);

            if (bf > 1)
            {
                if (balance(cNode.left.left, cNode.left.right) == 1)
                {
                    cNode = rightRotation(cNode);
                }
                else
                {
                    cNode.left = leftRotation(cNode.left);
                    cNode = rightRotation(cNode);
                }
            }
            else if (bf < -1)
            {
                if (balance(cNode.right.left, cNode.right.right) == -1)
                {
                    cNode = leftRotation(cNode);
                }
                else
                {
                    cNode.right = rightRotation(cNode.right);
                    cNode = leftRotation(cNode);
                }
            }
            return cNode;
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
        protected new Node deleteNode(int value, Node pNode)
        {
            if (pNode == null)
            {
                return pNode;
            }
            else if (pNode.data < value)
            {
                pNode.right = deleteNode(value, pNode.right);
            }
            else if (pNode.data > value)
            {
                pNode.left = deleteNode(value, pNode.left);
            }
            else
            {
                if (pNode.left != null && pNode.right != null)
                {
                    pNode.data = minNodeValue(pNode.right);
                    pNode.right = deleteNode(pNode.data, pNode.right);
                    return pNode;
                }
                else if (pNode.left != null)
                {
                    return pNode.left;

                }
                else if (pNode.right != null)
                {
                    return pNode.right;
                }
                return null;
            }
            var bf = balance(pNode.left, pNode.right);

            if (bf > 1)
            {
                if (balance(pNode.left.left, pNode.left.right) == 1)
                {
                    pNode = rightRotation(pNode);
                }
                else
                {
                    pNode.left = leftRotation(pNode.left);
                    pNode = rightRotation(pNode);
                }
            }
            else if (bf < -1)
            {
                if (balance(pNode.right.left, pNode.right.right) == -1)
                {
                    pNode = leftRotation(pNode);
                }
                else
                {
                    pNode.right = rightRotation(pNode.right);
                    pNode = leftRotation(pNode);
                }
            }
            // Console.WriteLine("Value: {0}, After Bal: {1}", pNode.data, balance(pNode.left, pNode.right));
            return pNode;
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
            if (this.balance(n.left, n.right) > 1 || this.balance(n.left, n.right) < -1)
            {
                return false;
            }
            return isAVLUtil(n.left) && isAVLUtil(n.right);
        }

        protected Node leftRotation(Node n)
        {
            Node b = n.right;
            n.right = b.left;
            b.left = n;
            return b;
        }

        protected Node rightRotation(Node n)
        {
            Node b = n.left;
            n.left = b.right;
            b.right = n;
            return b;
        }
    }
}