using System;
using Shouldly;
using Xunit;

namespace Lib.Integration.Tests
{
    public class CalculatorIntegrationTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, -2, -1)]
        [InlineData(-1, 2, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 2, 2)]
        [InlineData(0, 0, 0)]
        public void ShouldAddTwoOperands(int leftOp, int rightOp, int expectedResult)
        {
            // Given
            var calculator = new Calculator();

            // When
            var actualResult = calculator.Add(leftOp, rightOp);

            // Then
            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        [Trait("Integration", "true")]

        public void ShouldThrowOverflowExceptionWhenOverflow()
        {
            // Given
            var calculator = new Calculator();
            var leftOp = int.MaxValue;
            var rightOp = 1;

            // When
            void Overflow()
            {
                var actualResult = calculator.Add(leftOp, rightOp);
            }

            // Then
            Should.Throw<OverflowException>(Overflow);
        }
    }
}
