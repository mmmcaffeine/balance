using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class StackBasedBalancedCalculatorTests
    {
        [Theory]
        [ClassData(typeof(IsBalancedTestData))]
        public void Balance(string input, bool expectedIsBalanced)
        {
            // Arrange
            var sut = new StackBasedBalancedCalculator();

            // Act
            var isBalanced = sut.IsBalanced(input, IsBalancedTestData.Delimiters);
            
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}