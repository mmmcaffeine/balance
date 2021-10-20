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
            { "", "[", Array.Empty<int>() }
        };

        [Theory]
        [MemberData(nameof(IndicesOfTestData))]
        public void Baseline_Should_ReturnAllIndicesOfSubstring(string value, string substring, IEnumerable<int> expected)
        {
            IndicesOf.Baseline(value, substring).Should().BeEquivalentTo(expected);
        }
    }
}