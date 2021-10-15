using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class StackBasedBalancedCalculatorTests
    {
        [Theory]
        [ClassData(typeof(DelimitersOnlyTestData))]
        public void Balance(string input, IEnumerable<Delimiter> delimiters, bool expectedIsBalanced)
        {
            // Arrange
            var sut = new StackBasedBalancedCalculator();

            // Act
            var isBalanced = sut.IsBalanced(input, delimiters);
            
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}