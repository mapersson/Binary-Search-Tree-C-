using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trees.Tests
{
    [TestClass]
    public class BSTTests
    {

        public BSTTests()
        {

        }
        [TestMethod]
        public void ClassCreationTest()
        {
            BST newTree = new BST();

            Assert.IsNotNull(newTree);
        }

        [TestMethod]
        public void Search_Value_ReturnValue()
        {
            // Arrange
            int[] testData = { 11, 20, 29, 32, 41 };
            BST newTree = new BST();

            foreach (int i in testData)
            {
                newTree.insertValue(i);
            }

            // Action
            var returnValue = newTree.search(20);

            // Assert
            Assert.AreEqual(returnValue, 20);
        }

        [TestMethod]
        public void Search_NoneValue_ReturnSentinal()
        {
            // Arrange
            int[] testData = { 11, 20, 29, 32, 41 };
            BST newTree = new BST();

            foreach (int i in testData)
            {
                newTree.insertValue(i);
            }

            // Action
            var returnValue = newTree.search(44);
            // Assert
            Assert.AreEqual(returnValue, -1);
        }

        [TestMethod]
        public void Calculate_RightHeavyTreeHeight_ReturnsHeight()
        {
            int[] testData = { 11, 20, 29, 32, 41 };
            BST newTree = new BST();

            foreach (int i in testData)
            {
                newTree.insertValue(i);
            }

            var height = newTree.height();

            Assert.AreEqual(5, height);

        }
        [TestMethod]
        public void Calculate_BalancedTreeHeight_ReturnsHeight()
        {
            int[] testData = { 29, 20, 11, 21, 32, 30, 41 };
            BST newTree = new BST();

            foreach (int i in testData)
            {
                newTree.insertValue(i);
            }

            var height = newTree.height();

            Assert.AreEqual(3, height);
        }
        [TestMethod]
        public void Calculate_LeftTreeHeight_ReturnsHeight()
        {
            int[] testData = { 41, 32, 29, 20, 11 };
            BST newTree = new BST();

            foreach (int i in testData)
            {
                newTree.insertValue(i);
            }

            var height = newTree.height();

            Assert.AreEqual(5, height);
        }

        [TestMethod]
        public void Delete_NoSubNode_ReturnsNullAndBSTTest()
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

            BST myTree = new BST(root);

            myTree.deleteValue(2);

            Assert.IsTrue(myTree.isBST());
            Assert.AreEqual(-1, myTree.search(2));
        }

        [TestMethod]
        public void Delete_LeftSubNode_ReturnsNullAndBSTTest()
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

            BST myTree = new BST(root);

            myTree.deleteValue(3);

            Assert.IsTrue(myTree.isBST());
            Assert.AreEqual(-1, myTree.search(3));
        }
        [TestMethod]
        public void Delete_RightSubNode_ReturnsNullAndBSTTest()
        {
            // Arrange
            Node root = new Node(20);
            root.Left = new Node(4);
            root.Left.Left = new Node(3);
            root.Left.Left.Left = new Node(2);
            root.Left.Right = new Node(9);
            root.Left.Right.Right = new Node(11);
            root.Right = new Node(26);
            root.Right.Left = new Node(21);
            root.Right.Right = new Node(30);

            BST myTree = new BST(root);

            myTree.deleteValue(9);

            Assert.IsTrue(myTree.isBST());
            Assert.AreEqual(-1, myTree.search(9));
        }
        [TestMethod]
        public void Delete_BothSubNodes_ReturnsNullAndBSTTest()
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

            BST myTree = new BST(root);

            myTree.deleteValue(4);

            Assert.IsTrue(myTree.isBST());
            Assert.AreEqual(-1, myTree.search(4));
        }

        [TestMethod]
        public void Print_PopulatedTree_ReturnsString()
        {
            // Arrange
            BST tree = new BST();
            tree.insertValue(46);
            tree.insertValue(25);
            tree.insertValue(19);
            tree.insertValue(49);
            tree.insertValue(27);
            tree.insertValue(37);
            tree.insertValue(5);

            // Action

            var preOrderString = tree.printTree();

            // Assert
            Assert.AreEqual(" 46 25 19 5 27 37 49", preOrderString);

        }

        [TestMethod]
        public void Print_EmptyTree_ReturnsString()
        {
            // Arrange
            BST tree = new BST();

            // Action

            var preOrderString = tree.printTree();

            // Assert
            Assert.AreEqual("Empty Tree", preOrderString);

        }
    }
}
