namespace WordPlay.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WordPlay.Operations;

    [TestClass]
    public class SortOperationsTests
    {
        private SortOperation cut;

        [TestInitialize]
        public void Initialize()
        {
            this.cut = new SortOperation();
        }

        [TestMethod]
        public void ShouldSortStrings()
        {
            //Arrange
            var input = "[Test3 [Test2 [Test1]]]";
            const string expected = "Test1 Test2 Test3";

            //Act
            var hasOperation = this.cut.HasOpeation(input);
            var result = this.cut.Transform(input);

            //Assert
            Assert.IsTrue(hasOperation);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldSortChars()
        {
            //Arrange
            var input = "[e a c f d e c b d]";
            const string expected = "a b c c d d e e f";

            //Act
            var hasOperation = this.cut.HasOpeation(input);
            var result = this.cut.Transform(input);

            //Assert
            Assert.IsTrue(hasOperation);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldDoNothing()
        {
            //Arrange
            var input = "d b c";
            const string expected = "d b c";

            //Act
            var hasOperation = this.cut.HasOpeation(input);
            var result = this.cut.Transform(input);

            //Assert
            Assert.IsFalse(hasOperation);
            Assert.AreEqual(expected, result);
        }
    }
}
