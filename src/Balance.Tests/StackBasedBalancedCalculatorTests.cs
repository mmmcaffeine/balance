using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class StackBasedBalancedCalculatorTests
    {
        [Theory]
        [ClassData(typeof(DelimitersOnlyTestData))]
        public void Balance(string input, bool expectedIsBalanced)
        {
            // Arrange
            var sut = new StackBasedBalancedCalculator();

            // Act
            var isBalanced = sut.IsBalanced(input, DelimitersOnlyTestData.Delimiters);
            
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}