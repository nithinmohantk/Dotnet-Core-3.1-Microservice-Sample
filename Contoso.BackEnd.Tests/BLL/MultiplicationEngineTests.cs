using Contoso.BackEnd.BusinessLogic;

using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using Xunit;

namespace Contoso.BackEnd.Tests.BLL
{
    public class MultiplicationEngineTests
    {
        private ILogger<MultiplicationEngine> subLogger;

        public MultiplicationEngineTests()
        {
            this.subLogger = Substitute.For<ILogger<MultiplicationEngine>>();
        }

        private MultiplicationEngine CreateMultiplicationEngine()
        {
            return new MultiplicationEngine(
                this.subLogger);
        }

        [Fact]
        public void Multiply_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var multiplicationEngine = this.CreateMultiplicationEngine();
            int max = 0;

            // Act
            var result = multiplicationEngine.Multiply(
                max);

            // Assert
            Assert.True(false);
        }
    }
}
