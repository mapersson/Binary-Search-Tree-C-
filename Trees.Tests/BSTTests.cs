using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trees.Tests
{
    [TestClass]
    public class BSTTests : BST
    {

        public BSTTests()
        {
            int[] testData = { 11, 20, 29, 32, 41 };
            foreach (int i in testData)
            {
                this.insertNode(new Node(i));
            }

        }
        [TestMethod]
        public void ClassCreationTest()
        {
            Assert.IsNotNull(this);
        }

        [TestMethod]
        public void SearchValueTest()
        {
            Assert.AreEqual(this.search(20), 20);
        }

        [TestMethod]
        public void SearchMissingValueTest()
        {
            Assert.AreEqual(this.search(44), -1);
        }
    }
}
