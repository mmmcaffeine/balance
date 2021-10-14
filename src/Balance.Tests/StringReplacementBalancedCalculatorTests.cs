using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class StringReplacementBalancedCalculatorTests
    {
        // TODO Use MemberData to share these test cases with other implementations
        [Theory]
        [InlineData("[]", true)]
        [InlineData("{}", true)]
        [InlineData("()", true)]
        [InlineData("([)]", false)]
        [InlineData("([]", false)]
        [InlineData("{{)(}}", false)]
        [InlineData("({)}", false)]
        [InlineData("[({})]", true)]
        [InlineData("{}([])", true)]
        [InlineData("{()}[[{}]]", true)]
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