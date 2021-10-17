using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Dgt.Balance
{
    public class PairedIndicesBalancedCalculatorTests
    {
        [Theory]
        [MemberData(nameof(GetIndicesOfTestData))]
        public void IndicesOf_Should_ReturnIndicesOfSubstring(string value, string substring, IEnumerable<int> expectedIndices)
        {
            IndicesOf(value, substring).Should().Equal(expectedIndices);
        }
        
        private static TheoryData<string, string, IEnumerable<int>> GetIndicesOfTestData()
        {
            return new TheoryData<string, string, IEnumerable<int>>
            {
                { "No parens", ")", Array.Empty<int>() },
                { "()", ")", new[] { 1 } },
                { "ABC (()) DEF ()", "(", new[] { 4, 5, 13 } },
                { "ABC (()) ABC (())", "ABC", new[] { 0, 9 } }
            };
        }

        private static IEnumerable<int> IndicesOf(string value, string substring)
        {
            var indices = new List<int>();
            var index = 0;

            while ((index = value.IndexOf(substring, index, StringComparison.Ordinal)) != -1)
            {
                indices.Add(index++);
            }

            return indices;
        }
    }
}