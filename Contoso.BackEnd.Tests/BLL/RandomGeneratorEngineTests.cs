using Contoso.BackEnd.Generator.Api.BLL;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Contoso.BackEnd.Tests.BLL
{
    public class RandomGeneratorEngineTests
    {
        private ILogger<RandomGeneratorEngine> subLogger;

        public RandomGeneratorEngineTests()
        {
            this.subLogger = Substitute.For<ILogger<RandomGeneratorEngine>>();
        }

        private RandomGeneratorEngine CreateRandomGeneratorEngine()
        {
            return new RandomGeneratorEngine(
                this.subLogger);
        }

        [Fact]
        public async Task Generate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var randomGeneratorEngine = this.CreateRandomGeneratorEngine();
            int range = 0;

            // Act
            var result = await randomGeneratorEngine.Generate(
                range);

            // Assert
            Assert.True(false);
        }
    }
}
