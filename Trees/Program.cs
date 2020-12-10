using System;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Node myNode = new Node(50);
            BST myTree = new BST(myNode);
            Node secondNode = new Node(45);
            myTree.insertNode(secondNode);
            Node thirdNode = new Node(55);
            myTree.insertNode(thirdNode);
            Node fourthNode = new Node(43);
            myTree.insertNode(fourthNode);
            Node FifthNode = new Node(46);
            myTree.insertNode(FifthNode);

            var rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                Node newNode = new Node(rand.Next(0, 100));
                myTree.insertNode(newNode);
            }

            Console.Write("{0}", myTree.height());
            Console.WriteLine();
            myTree.printTree();



        }

    }
}