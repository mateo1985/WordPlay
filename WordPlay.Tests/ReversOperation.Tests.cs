namespace WordPlay.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WordPlay.Operations;

    [TestClass]
    public class ReversOperationTests
    {
        private ReverseOperation cut;

        [TestInitialize]
        public void Initialize()
        {
            this.cut = new ReverseOperation();
        }

        [TestMethod]
        public void ShouldReverseStrings()
        {
            //Arrange
            var input = "Test1 (Test2 (Test3))";
            const string expected = "Test1 Test3 2tseT";

            //Act
            var hasOperation = this.cut.HasOpeation(input);
            var result = this.cut.Transform(input);

            //Assert
            Assert.IsTrue(hasOperation);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldNotReverseStrings()
        {
            //Arrange
            var input = "Test1 ((Test2))";
            const string expected = "Test1 Test2";

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
            var input = "Test1 Test2";
            const string expected = "Test1 Test2";

            //Act
            var hasOperation = this.cut.HasOpeation(input);
            var result = this.cut.Transform(input);

            //Assert
            Assert.IsFalse(hasOperation);
            Assert.AreEqual(expected, result);
        }
    }
}
