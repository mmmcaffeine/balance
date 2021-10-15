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

            // Act
            var isBalanced = sut.IsBalanced(input, IsBalancedTestData.Delimiters);
        
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}