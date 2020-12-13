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
        public void SearchValueTest()
        {
            int[] testData = { 11, 20, 29, 32, 41 };
            BST newTree = new BST();

            foreach (int i in testData)
            {
                newTree.insertNode(i);
            }

            var returnValue = newTree.search(20);

            Assert.AreEqual(returnValue, 20);
        }

        [TestMethod]
        public void SearchMissingValueTest()
        {
            int[] testData = { 11, 20, 29, 32, 41 };
            BST newTree = new BST();

            foreach (int i in testData)
            {
                newTree.insertNode(i);
            }

            var returnValue = newTree.search(44);

            Assert.AreEqual(returnValue, -1);
        }

        [TestMethod]
        public void Calculate_RightHeavyTreeHeight_ReturnsHeight()
        {
            int[] testData = { 11, 20, 29, 32, 41 };
            BST newTree = new BST();

            foreach (int i in testData)
            {
                newTree.insertNode(i);
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
                newTree.insertNode(i);
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
                newTree.insertNode(i);
            }

            var height = newTree.height();

            Assert.AreEqual(5, height);
        }
    }
}
