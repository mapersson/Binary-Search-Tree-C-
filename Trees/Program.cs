using System;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Node myNode = new Node(11);
            BST myTree = new BST(myNode);
            Node secondNode = new Node(20);
            myTree.insertNode(20);
            Node thirdNode = new Node(29);
            myTree.insertNode(29);
            Node fourthNode = new Node(32);
            myTree.insertNode(32);
            Node fifthNode = new Node(41);
            myTree.insertNode(41);

            Node sixthNode = new Node(65);
            Node seventhNode = new Node(50);
            Node eightNode = new Node(91);
            Node ninthNode = new Node(72);
            Node tenthNode = new Node(99);

            AVL myAVLTree = new AVL();
            myAVLTree.insertNode(11);
            myAVLTree.insertNode(20);
            myAVLTree.insertNode(29);
            myAVLTree.insertNode(32);
            myAVLTree.insertNode(41);
            myAVLTree.insertNode(65);
            myAVLTree.insertNode(50);
            myAVLTree.insertNode(91);
            myAVLTree.insertNode(72);
            myAVLTree.insertNode(99);

            // var rand = new Random();

            // for (int i = 0; i < 5; i++)
            // {
            //     Node newNode = new Node(rand.Next(0, 100));
            //     myTree.insertNode(newNode);
            //     myAVLTree.insertNode(newNode);
            // }

            // Console.Write("{0}", myTree.height());
            // Console.WriteLine();
            // myTree.printTree();

            Console.WriteLine();
            Console.Write("{0}", myAVLTree.height());
            Console.WriteLine();
            myAVLTree.printTree();

            Console.WriteLine("Is BST: {0}", myAVLTree.isBST());

            Console.WriteLine("Is AVL: {0}", myAVLTree.isAVL());




        }

    }
}