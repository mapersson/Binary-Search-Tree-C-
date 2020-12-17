using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {

            BST myTree = new BST();

            myTree.insertValue(12);
            myTree.insertValue(8);
            myTree.insertValue(11);
            myTree.insertValue(5);
            myTree.insertValue(4);
            myTree.insertValue(18);
            myTree.insertValue(17);

            Console.WriteLine(myTree.printTree());
            AVL myAVLTree = new AVL();

            myAVLTree.insertValue(12);
            myAVLTree.insertValue(8);
            myAVLTree.insertValue(11);
            myAVLTree.insertValue(5);
            myAVLTree.insertValue(4);
            myAVLTree.insertValue(18);
            myAVLTree.insertValue(17);

            Console.WriteLine(myAVLTree.printTree());


        }

    }
}