using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
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

        [Fact]
        public void FindImmediatePairs_Should_ReturnPairsThatDoNotEncompassStartOrEndOfOtherPairs()
        {
            // Arrange
            // Indices taken from the expression "x = Sum((a + b), (c + d));"
            // We should find the parens that are the sub-expressions of "(a + b)" and "(c + d)" because they do _not_
            // contain any other opening or closing parens within them. We should _not_ find the parens for "Sum(...)"
            // because they _do_ contain other opening and closing parens
            var pairs = new List<(int Start, int End)> { (7, 24), (8, 14), (17, 23) };
            
            // Act
            var immediatePairs = FindImmediatePairs(pairs);

            // Assert
            // We don't care about the ordering of these
            immediatePairs.Should().BeEquivalentTo(new[] { (8, 14), (17, 23) });
        }

        private static IEnumerable<(int Start, int End)> FindImmediatePairs(IReadOnlyCollection<(int Start, int End)> pairs)
        {
            return pairs.Where(firstPair => pairs.Except(firstPair).None(secondPair => Overlaps(secondPair, firstPair)));

            bool Overlaps((int Start, int End) x, (int Start, int End) y) => StartOverlaps(x, y) || EndOverlaps(x, y);

            bool StartOverlaps((int Start, int End) x, (int Start, int End) y) => x.Start >= y.Start && x.Start <= y.End;

            bool EndOverlaps((int Start, int End) x, (int Start, int End) y) => x.End >= y.Start && x.End <= y.End;
        }
    }
}