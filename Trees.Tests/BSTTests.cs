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
            root.left = new Node(4);
            root.left.left = new Node(3);
            root.left.left.left = new Node(2);
            root.left.right = new Node(9);
            root.left.right.left = new Node(7);
            root.left.right.right = new Node(11);
            root.right = new Node(26);
            root.right.left = new Node(21);
            root.right.right = new Node(30);

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
            root.left = new Node(4);
            root.left.left = new Node(3);
            root.left.left.left = new Node(2);
            root.left.right = new Node(9);
            root.left.right.left = new Node(7);
            root.left.right.right = new Node(11);
            root.right = new Node(26);
            root.right.left = new Node(21);
            root.right.right = new Node(30);

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
            root.left = new Node(4);
            root.left.left = new Node(3);
            root.left.left.left = new Node(2);
            root.left.right = new Node(9);
            root.left.right.right = new Node(11);
            root.right = new Node(26);
            root.right.left = new Node(21);
            root.right.right = new Node(30);

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
            root.left = new Node(4);
            root.left.left = new Node(3);
            root.left.left.left = new Node(2);
            root.left.right = new Node(9);
            root.left.right.left = new Node(7);
            root.left.right.right = new Node(11);
            root.right = new Node(26);
            root.right.left = new Node(21);
            root.right.right = new Node(30);

            BST myTree = new BST(root);

            myTree.deleteValue(4);

            Assert.IsTrue(myTree.isBST());
            Assert.AreEqual(-1, myTree.search(4));
        }
    }
}
