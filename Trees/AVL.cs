
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

        private int balance(Node ln, Node rn)
        {
            return nodeHeight(ln) - nodeHeight(rn);
        }

        /*
        IF tree is right heavy (balance < -1)
            IF tree's right subtree is left heavy
                Double Left Rotation or Left Right 
            ELSE
                Single Left Rotation
        ELSE IF tree is left heavy (balance > 1)
            IF tree's left subtree is right heavy
                Double Right Rotation or Right Left
            ELSE 
                Single Right Rotation
        */

        public new void insertNode(int value)
        {
            root = insertNode(value, root);
        }

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
            if (value > cNode.data)
            {
                cNode.right = insertNode(value, cNode.right);
            }
            if (value < cNode.data)
            {
                cNode.left = insertNode(value, cNode.left);
            }

            Console.WriteLine("Value: {0}, Before Bal: {1}", cNode.data, balance(cNode.left, cNode.right));

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
            Console.WriteLine("Value: {0}, After Bal: {1}", cNode.data, balance(cNode.left, cNode.right));
            return cNode;
        }

        public new void deleteValue(int value)
        {
            root = deleteNode(value, root);
        }

        protected new Node deleteNode(int value, Node pNode)
        {
            if (pNode == null)
            {
                return pNode;
            }
            if (pNode.data < value)
            {
                pNode.right = deleteNode(value, pNode.right);
            }
            if (pNode.data > value)
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
            Console.WriteLine("Value: {0}, After Bal: {1}", pNode.data, balance(pNode.left, pNode.right));
            return pNode;
        }
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