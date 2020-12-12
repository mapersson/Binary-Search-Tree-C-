using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trees.Tests
{
    [TestClass]
    public class BSTTests
    {
        private BST _bst;

        public BSTTests()
        {
            _bst = new BST();
        }
        [TestMethod]
        public void ClassCreationTest()
        {
            Assert.IsNotNull(_bst);
        }
    }
}
