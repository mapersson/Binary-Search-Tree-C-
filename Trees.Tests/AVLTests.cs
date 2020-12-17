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
            newTree.insertValue(15);

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
            root.left = new Node(4);
            root.left.left = new Node(3);
            root.left.right = new Node(9);
            root.right = new Node(26);

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
            root.left = new Node(4);
            root.left.left = new Node(3);
            root.left.right = new Node(9);
            root.right = new Node(26);

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
            root.left = new Node(4);
            root.left.left = new Node(3);
            root.left.left.left = new Node(2);
            root.left.right = new Node(9);
            root.left.right.left = new Node(7);
            root.left.right.right = new Node(11);
            root.right = new Node(26);
            root.right.left = new Node(21);
            root.right.right = new Node(30);

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
            root.left = new Node(4);
            root.left.left = new Node(3);
            root.left.left.left = new Node(2);
            root.left.right = new Node(9);
            root.left.right.left = new Node(7);
            root.left.right.right = new Node(11);
            root.right = new Node(26);
            root.right.left = new Node(21);
            root.right.right = new Node(30);

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
            root.left = new Node(1);
            root.right = new Node(4);
            root.right.left = new Node(3);
            root.right.right = new Node(5);

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
            root.left = new Node(2);
            root.left.left = new Node(1);
            root.left.right = new Node(4);
            root.left.right.left = new Node(3);
            root.left.right.right = new Node(5);

            root.right = new Node(9);
            root.right.left = new Node(8);
            root.right.left.left = new Node(7);
            root.right.right = new Node(15);
            root.right.right.left = new Node(14);
            root.right.right.right = new Node(16);
            root.right.right.right.right = new Node(17);

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
            root.left = new Node(2);
            root.left.left = new Node(1);
            root.left.right = new Node(3);
            root.left.right.right = new Node(4);

            root.right = new Node(8);
            root.right.left = new Node(7);
            root.right.left.left = new Node(6);
            root.right.right = new Node(10);
            root.right.right.left = new Node(9);
            root.right.right.right = new Node(12);
            root.right.right.right.right = new Node(17);

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