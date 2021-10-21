using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Dgt.Dojo.Optimisations
{
    public class IndicesOfTests
    {
        public static TheoryData<string, string, IEnumerable<int>> IndicesOfTestData => new()
        {
            { "(())()", "(", new[] { 0, 1, 4 } },
            { "(())()", ")", new[] { 2, 3, 5 } },
            { "()()", "[", Array.Empty<int>() },
            { "", "[", Array.Empty<int>() },
            { "var x = Sum(new[] {1, 3, 5, 7});", ", ", new[] { 20, 23, 26 } }
        };

        [Theory]
        [MemberData(nameof(IndicesOfTestData))]
        public void Baseline_Should_ReturnAllIndicesOfSubstring(string value, string substring, IEnumerable<int> expected)
        {
            IndicesOf.Baseline(value, substring).Should().BeEquivalentTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(IndicesOfTestData))]
        public void A_YieldReturn_Should_ReturnAllIndicesOfSubstring(string value, string substring, IEnumerable<int> expected)
        {
            IndicesOf.A_YieldReturn(value, substring).Should().BeEquivalentTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(IndicesOfTestData))]
        public void B_UsingSpanAndList_Should_ReturnAllIndicesOfSubstring(string value, string substring, IEnumerable<int> expected)
        {
            IndicesOf.B_UsingSpanAndList(value, substring).Should().BeEquivalentTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(IndicesOfTestData))]
        public void C_UsingSpanAndStack_Should_ReturnAllIndicesOfSubstring(string value, string substring, IEnumerable<int> expected)
        {
            IndicesOf.C_UsingSpanAndStack(value, substring).Should().BeEquivalentTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(IndicesOfTestData))]
        public void D_ManualComparisonOfSpans_Should_ReturnAllIndicesOfSubstring(string value, string substring, IEnumerable<int> expected)
        {
            IndicesOf.D_ManualComparisonOfSpans(value, substring).Should().BeEquivalentTo(expected);
        }
    }
}