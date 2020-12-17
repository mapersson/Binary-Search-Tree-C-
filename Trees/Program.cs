﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {

            BST myTree = new BST();

            var random = new Random();
            var numSet = new HashSet<int>();
            for (int i = 0; i < 10; i++)
            {
                numSet.Add(random.Next(10, int.MaxValue));
            }

            foreach (int item in numSet)
            {
                myTree.insertValue(item);
            }

            myTree.insertValue(5);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var findValue = myTree.search(5);
            watch.Stop();
            Console.WriteLine("Set Size {0}", numSet.Count);
            Console.WriteLine("Found Value: {0}", findValue);
            Console.WriteLine("BST Elapsed Ticks: {0}", watch.ElapsedTicks);
            myTree.printTree();
            AVL myAVLTree = new AVL();

            foreach (int item in numSet)
            {
                myAVLTree.insertValue(item);
            }

            myAVLTree.insertValue(5);
            watch.Reset();
            watch.Start();
            var findAVLValue = myTree.search(5);
            watch.Stop();
            Console.WriteLine("Set Size {0}", numSet.Count);
            Console.WriteLine("AVL Found Value: {0}", findAVLValue);
            Console.WriteLine("AVL Elapsed Ticks: {0}", watch.ElapsedTicks);


        }

    }
}