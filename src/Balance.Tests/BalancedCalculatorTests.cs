using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class BalancedCalculatorTests
    {
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
            (char Start, char End)[] delimiters =
            {
                ('{', '}'),
                ('[', ']'),
                ('(', ')')
            };

            // Act
            var isBalanced = BalancedCalculator.IsBalanced(input, delimiters);
            
            // Assert
            isBalanced.Should().Be(expectedIsBalanced);
        }
    }
}