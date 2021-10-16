using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Dgt.Balance
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
    }
}