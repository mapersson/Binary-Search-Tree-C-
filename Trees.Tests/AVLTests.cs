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
            int[] testData = { 10, 1 };
            AVL newTree = new AVL();

            foreach (int i in testData)
            {
                newTree.insertNode(i);
            }

            // Action
            newTree.insertNode(5);

            // Assert
            var height = newTree.height();
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
            myTree.insertNode(15);

            // Assert
            var height = myTree.height();
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
            myTree.insertNode(15);

            // Assert
            var height = myTree.height();
            Assert.AreEqual(4, height);
        }
    }
}