using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class StringReplacementBalancedCalculatorTests
    {
        [Theory]
        [ClassData(typeof(DelimitersOnlyTestData))]
        public void Balance(string input, IEnumerable<Delimiter> delimiters, bool expectedIsBalanced)
        {
            // Arrange
            var sut = new StringReplacementBalancedCalculator();

            // Act
            var isBalanced = sut.IsBalanced(input, delimiters);
        
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}