namespace WordPlay.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using WordPlay.Operations;
    using WordPlay.Transformations;


    [TestClass]
    public class IntegrationTests
    {
        private TransformString cut;
        
        [TestInitialize]
        public void Initialize()
        {
            var operationManager = new OperationsManager();
            operationManager.RegisterOperation(new ReverseOperation());
            operationManager.RegisterOperation(new SortOperation());

            this.cut = new TransformString(operationManager);
        }

        [TestMethod]
        public void ShouldNotChangeAnything()
        {
            // Arrange
            var input = "Tests of a sample supplied by MeMFIS";

            // Act
            var result = cut.TransfromString(input);

            // Assert
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void ShouldMakeTheRoundFirst()
        {
            // Arrange
            var input = "Tests of a [(sample of example)] supplied by MeMFIS";
            const string expected = "Tests of a elpmas elpmaxe fo supplied by MeMFIS";

            // Act
            var result = cut.TransfromString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldMatchExample1()
        {
            // Arrange
            var input = "Tests of a (sample) supplied by MeMFIS";
            const string expected = "Tests of a elpmas supplied by MeMFIS";
            
            // Act
            var result = cut.TransfromString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldMatchExample2()
        {
            // Arrange
            var input = "Tests of a sample [supplied by MeMFIS]";
            const string expected = "Tests of a sample by MeMFIS supplied";

            // Act
            var result = cut.TransfromString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldMatchExample3()
        {
            // Arrange
            var input = "Tests of [a (sample supplied)] by MeMFIS";
            const string expected = "Tests of a deilppus elpmas by MeMFIS";

            // Act
            var result = cut.TransfromString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void ShouldMatchExample4()
        {
            // Arrange
            var input = "Tests of [a ((sample) supplied)] by MeMFIS";
            const string expected = "Tests of a deilppus sample by MeMFIS";

            // Act
            var result = cut.TransfromString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
