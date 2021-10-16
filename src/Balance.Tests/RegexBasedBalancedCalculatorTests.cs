using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class RegexBasedBalancedCalculatorTests
    {
        [Theory]
        [ClassData(typeof(DelimitersOnlyTestData))]
        [ClassData(typeof(DelimitedStringsTestData))]
        [ClassData(typeof(MultiCharacterDelimiterTestData))]
        public void IsBalanced_Should_ReturnTrueWhenDelimitersAreBalanced
            (string input, IEnumerable<Delimiter> delimiters, bool expectedIsBalanced)
        {
            // Arrange
            var sut = new RegexBasedBalancedCalculator();

            // Act
            var isBalanced = sut.IsBalanced(input, delimiters);
        
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}