using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
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
        
        [Fact]
        public void IndicesOf_Should_ReturnIndicesOfStartAndEnd()
        {
            // Arrange, Act
            var (delimiter,  startIndices, endIndices) = IndicesOf("x = Sum((a + b), (c + d));", Delimiter.Parentheses);

            // Assert
            using (new AssertionScope())
            {
                delimiter.Should().Be(Delimiter.Parentheses);
                startIndices.Should().Equal(7, 8, 17);
                endIndices.Should().Equal(14, 23, 24);
            }
        }

        private static (Delimiter Delimiter, List<int> StartIndices, List<int> EndIndices) IndicesOf(string value, Delimiter delimiter)
        {
            var startIndices = IndicesOf(value, delimiter.Start).ToList();
            var endIndices = IndicesOf(value, delimiter.End).ToList();

            return (delimiter, startIndices, endIndices);
        }
        
        [Fact]
        public void PairIndices_Should_PairStartAndEndIndices()
        {
            // Arrange
            // Indices taken from the expression "x = Sum((a + b), (c + d));"
            var startIndices = new List<int> { 7, 8, 17 };
            var endIndices = new List<int> { 14, 23, 24 };
            
            // Act
            var pairedIndices = PairIndices(startIndices, endIndices);
            
            // Assert
            pairedIndices.Should().Equal((7, 24), (8, 14), (17, 23));
        }

        private static IEnumerable<(int Start, int End)> PairIndices(IEnumerable<int> startIndices, IEnumerable<int> endIndices)
        {
            var remainingStartIndices = new Queue<int>(startIndices.OrderByDescending(i => i));
            var remainingEndIndices = endIndices.ToList();
            var pairedIndices = new List<(int, int)>();

            while (remainingStartIndices.Any())
            {
                var startIndex = remainingStartIndices.Dequeue();
                var endIndex = remainingEndIndices.Find(i => i > startIndex); // We might not find the end index...

                pairedIndices.Add((startIndex, endIndex));
                remainingEndIndices.Remove(endIndex);
            }
            
            return pairedIndices.OrderBy(t => t.Item1).ToList();
        }
    }
}