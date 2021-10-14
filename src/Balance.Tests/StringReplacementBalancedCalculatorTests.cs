using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class StringReplacementBalancedCalculatorTests
    {
        [Theory]
        [ClassData(typeof(IsBalancedTestData))]
        public void Balance(string input, bool expectedIsBalanced)
        {
            // Arrange
            var sut = new StringReplacementBalancedCalculator();
            var delimiters = new[]
            {
                Delimiter.Braces,
                Delimiter.Brackets,
                Delimiter.Parentheses
            };

            // Act
            var isBalanced = sut.IsBalanced(input, delimiters);
        
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}