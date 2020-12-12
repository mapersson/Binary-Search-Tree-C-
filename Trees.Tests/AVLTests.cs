using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trees.Tests
{
    [TestClass]
    public class AVLTests
    {

        private AVL _avl;

        public AVLTests()
        {
            _avl = new AVL();
        }
        [TestMethod]
        public void ClassCreationTest()
        {
            Assert.IsNotNull(_avl);
        }
    }
}