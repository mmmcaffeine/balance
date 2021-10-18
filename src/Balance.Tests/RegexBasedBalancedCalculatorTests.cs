using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Dgt.Dojo.Balance
{
    public class RegexBasedBalancedCalculatorTests
    {
        private readonly ITestOutputHelper _output;

        public RegexBasedBalancedCalculatorTests(ITestOutputHelper output)
        {
            _output = output;
        }

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

        [Theory]
        [InlineData(@"<%-- ASPX Comment --%>",      @"<%-- ASPX Comment --%>", true)]  // Simple case
        [InlineData(@"<%-- <%-- ASPX Comment --%>", @"<%-- ASPX Comment --%>", true)]  // Should match and leave the unbalanced starting delimiter
        [InlineData(@"<%-- ASPX Comment --%> --%>", @"<%-- ASPX Comment --%>", true)]  // Should match and leave the unbalanced ending delimiter
        [InlineData(@"ASPX Comment --%>",           "",                        false)] // No starting delimiter
        [InlineData(@"<%-- ASPX Comment",           "",                        false)] // No ending delimiter
        [InlineData(@"<%--/*--%>",                  "",                        false)] // Contains starting multiline comment delimiter
        [InlineData(@"<%--*/--%>",                  "",                        false)] // Contains ending multiline comment delimiter
        public void NegativeLookAhead_Should_FilterNestedMultiCharacterDelimiters
            (string input, string expectedValue, bool expectedSuccess)
        {
            const string pattern = @"<%--((?!(/\*|\*/|<%--|--%>)).)*?--%>";
            var match = Regex.Match(input, pattern);
            
            _output.WriteLine(match.Value);

            match.Success.Should().Be(expectedSuccess);
            match.Value.Should().Be(expectedValue);
        }

        [Fact]
        public void CreatePattern_Should_BuildPatternNegativeLookaheadUsingAlternation()
        {
            // Arrange
            var currentDelimiter = Delimiter.AspxComment;
            var allDelimiters = new[] { Delimiter.HtmlComment, Delimiter.RazorComment, Delimiter.AspxComment };

            // Act
            var start = currentDelimiter.EscapeStart();
            var end = currentDelimiter.EscapeEnd();
            var allDelimiterStrings = allDelimiters.SelectMany(x => new[] { x.EscapeStart(), x.EscapeEnd() });
            var alternationOfAllDelimiters = string.Join('|', allDelimiterStrings);

            var pattern = $@"{start}((?!({alternationOfAllDelimiters})).)*?{end}";

            // Assert
            pattern.Should().Be(@"<%--((?!(<!--|-->|@\*|\*@|<%--|--%>)).)*?--%>");
        }
    }
}