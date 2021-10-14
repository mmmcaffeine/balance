using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class BalancedCalculatorTests
    {
        [Theory]
        [ClassData(typeof(IsBalancedTestData))]
        public void Balance(string input, bool expectedIsBalanced)
        {
            // Arrange
            var delimiters = new[]
            {
                Delimiter.Braces,
                Delimiter.Brackets,
                Delimiter.Parentheses
            };

            // Act
            var isBalanced = BalancedCalculator.IsBalanced(input, delimiters);
            
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}