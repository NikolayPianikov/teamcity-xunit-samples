using System;
using Xunit;
using Shouldly;

namespace Lib.Tests
{
    public class CalculatorTests
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
        public void ShouldThrowOverflowExceptionWhenOverflow()
        {
            // Given
            var calculator = new Calculator();

            // When
            void Overflow()
            {
                calculator.Add(int.MaxValue, 1);
            }

            // Then
            Should.Throw<OverflowException>(Overflow);
        }
    }
}
