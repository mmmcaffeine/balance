using FluentAssertions;
using Xunit;

namespace Dgt.Dojo.Optimisations
{
    public class IntParseTests
    {
        public static TheoryData<string, int> IntParseTestData => new()
        {
            { "1976", 1976 },
            { "3412", 3412 },
            { "19991231", 19991231 }
        };

        [Theory]
        [MemberData(nameof(IntParseTestData))]
        public void Baseline_Should_ParseIntFromString(string value, int expected)
        {
            IntParse.Baseline(value).Should().Be(expected);
        }
        
        [Theory]
        [MemberData(nameof(IntParseTestData))]
        public void A_TwoLoopVariables_Should_ParseIntFromString(string value, int expected)
        {
            IntParse.A_TwoLoopVariables(value).Should().Be(expected);
        }
        
        [Theory]
        [MemberData(nameof(IntParseTestData))]
        public void B_MathOperations_Should_ParseIntFromString(string value, int expected)
        {
            IntParse.B_MathOperations(value).Should().Be(expected);
        }
        
        [Theory]
        [MemberData(nameof(IntParseTestData))]
        public void C_EnumerateBackwardsForPowersOfTen_Should_ParseIntFromString(string value, int expected)
        {
            IntParse.C_EnumerateBackwardsForPowersOfTen(value).Should().Be(expected);
        }
        
        [Theory]
        [MemberData(nameof(IntParseTestData))]
        public void D_NoSpan_Should_ParseIntFromReadOnlySpanOfChar(string value, int expected)
        {
            IntParse.D_NoSpan(value).Should().Be(expected);
        }
        
        [Theory]
        [MemberData(nameof(IntParseTestData))]
        public void E_InputSpan_Should_ParseIntFromReadOnlySpanOfChar(string value, int expected)
        {
            IntParse.E_InputSpan(value).Should().Be(expected);
        }
    }
}