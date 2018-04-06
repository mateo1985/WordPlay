using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace WordPlay.Tests
{
    using System;
    using WordPlay.Transformations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TransformStringTests
    {

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "input")]
        public void ShouldThrowContainsAnyChar()
        {
            //Arrange
            IOperationsManagable manager = null;
            var cut = new TransformString(manager);

            //Act
            cut.TransfromString(null);
            
        }

        [TestMethod]
        public void ShouldReturnsInput()
        {
            //Arrange
            IOperationsManagable manager = null;
            var cut = new TransformString(manager);
            const string input = "This is the [expected (input)]";

            //Act
            var result = cut.TransfromString(input);

            //Assert
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void ShouldNotInvokeAnyOperations()
        {
            //Arrange
            string input = "Example string";
            var operation1 = new Mock<ITransformable>();
            var operation2 = new Mock<ITransformable>();
            
            var list = new List<ITransformable>
            {
                operation1.Object,
                operation2.Object
            };

            var operationManager = new Mock<IOperationsManagable>();
            operationManager.Setup(x => x.GetEnumerator()).Returns(list.GetEnumerator());
            
            var transformString = new TransformString(operationManager.Object);

            //Act
            transformString.TransfromString(input);

            //Assert
            operation1.Verify(x => x.HasOpeation(input));
            operation2.Verify(x => x.HasOpeation(input));

            operation1.Verify(x => x.Transform(input), Times.Never());
            operation2.Verify(x => x.Transform(input), Times.Never());
        }
    }
}
