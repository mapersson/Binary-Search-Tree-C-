using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trees.Tests
{
    [TestClass]
    public class AVLTests
    {

        public AVLTests()
        {

        }
        [TestMethod]
        public void ClassCreationTest()
        {
            AVL newTree = new AVL();
            Assert.IsNotNull(newTree);
        }

        [TestMethod]
        public void Insert_LeftBranchAddition_Case1a()
        {

            // Arrange
            int[] testData = { 20, 4 };
            AVL newTree = new AVL();

            foreach (int i in testData)
            {
                newTree.insertValue(i);
            }

            // Action
            newTree.insertValue(15);

            // Assert
            var height = newTree.height();
            Assert.IsTrue(newTree.isAVL());
            Assert.AreEqual(2, height);
        }

        [TestMethod]
        public void Insert_LeftBranchAddition_Case1b()
        {

            // Arrange
            int[] testData = { 20, 4 };
            AVL newTree = new AVL();

            foreach (int i in testData)
            {
                newTree.insertValue(i);
            }

            // Action
            newTree.insertValue(8);

            // Assert
            var height = newTree.height();
            Assert.IsTrue(newTree.isAVL());
            Assert.AreEqual(2, height);
        }

        [TestMethod]
        public void Insert_LeftBranchAddition_Case2a()
        {

            // Arrange
            Node root = new Node(20);
            root.Left = new Node(4);
            root.Left.Left = new Node(3);
            root.Left.Right = new Node(9);
            root.Right = new Node(26);

            AVL myTree = new AVL(root);

            //Action
            myTree.insertValue(15);

            // Assert
            var height = myTree.height();
            Assert.IsTrue(myTree.isAVL());
            Assert.AreEqual(3, height);
        }

        [TestMethod]
        public void Insert_LeftBranchAddition_Case2b()
        {

            // Arrange
            Node root = new Node(20);
            root.Left = new Node(4);
            root.Left.Left = new Node(3);
            root.Left.Right = new Node(9);
            root.Right = new Node(26);

            AVL myTree = new AVL(root);

            //Action
            myTree.insertValue(8);

            // Assert
            var height = myTree.height();
            Assert.IsTrue(myTree.isAVL());
            Assert.AreEqual(3, height);
        }

        [TestMethod]
        public void Insert_LeftBranchAddition_Case3a()
        {
            // Arrange
            Node root = new Node(20);
            root.Left = new Node(4);
            root.Left.Left = new Node(3);
            root.Left.Left.Left = new Node(2);
            root.Left.Right = new Node(9);
            root.Left.Right.Left = new Node(7);
            root.Left.Right.Right = new Node(11);
            root.Right = new Node(26);
            root.Right.Left = new Node(21);
            root.Right.Right = new Node(30);

            AVL myTree = new AVL(root);

            // Action
            myTree.insertValue(15);

            // Assert
            var height = myTree.height();
            Assert.IsTrue(myTree.isAVL());
            Assert.AreEqual(4, height);
        }
        [TestMethod]
        public void Insert_LeftBranchAddition_Case3b()
        {
            // Arrange
            Node root = new Node(20);
            root.Left = new Node(4);
            root.Left.Left = new Node(3);
            root.Left.Left.Left = new Node(2);
            root.Left.Right = new Node(9);
            root.Left.Right.Left = new Node(7);
            root.Left.Right.Right = new Node(11);
            root.Right = new Node(26);
            root.Right.Left = new Node(21);
            root.Right.Right = new Node(30);

            AVL myTree = new AVL(root);

            // Action
            myTree.insertValue(8);

            // Assert
            var height = myTree.height();
            Assert.IsTrue(myTree.isAVL());
            Assert.AreEqual(4, height);
        }

        [TestMethod]
        public void Delete_Case1()
        {
            // Arrange
            Node root = new Node(2);
            root.Left = new Node(1);
            root.Right = new Node(4);
            root.Right.Left = new Node(3);
            root.Right.Right = new Node(5);

            AVL myTree = new AVL(root);

            // Action
            myTree.deleteValue(1);

            // Assert
            Assert.IsTrue(myTree.isAVL());
            Assert.AreEqual(-1, myTree.search(1));
        }

        [TestMethod]
        public void Delete_Case2()
        {
            // Arrange
            Node root = new Node(6);
            root.Left = new Node(2);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(4);
            root.Left.Right.Left = new Node(3);
            root.Left.Right.Right = new Node(5);

            root.Right = new Node(9);
            root.Right.Left = new Node(8);
            root.Right.Left.Left = new Node(7);
            root.Right.Right = new Node(15);
            root.Right.Right.Left = new Node(14);
            root.Right.Right.Right = new Node(16);
            root.Right.Right.Right.Right = new Node(17);

            AVL myTree = new AVL(root);

            // Action
            myTree.deleteValue(1);

            // Assert
            Assert.IsTrue(myTree.isAVL());
            Assert.AreEqual(-1, myTree.search(1));
        }

        [TestMethod]
        public void Delete_Case3()
        {
            // Arrange
            Node root = new Node(5);
            root.Left = new Node(2);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(3);
            root.Left.Right.Right = new Node(4);

            root.Right = new Node(8);
            root.Right.Left = new Node(7);
            root.Right.Left.Left = new Node(6);
            root.Right.Right = new Node(10);
            root.Right.Right.Left = new Node(9);
            root.Right.Right.Right = new Node(12);
            root.Right.Right.Right.Right = new Node(17);

            AVL myTree = new AVL(root);
            Assert.IsTrue(myTree.isAVL());

            // Action
            myTree.deleteValue(1);

            // Assert
            Assert.IsTrue(myTree.isAVL());
            Assert.AreEqual(-1, myTree.search(1));
        }
    }
}