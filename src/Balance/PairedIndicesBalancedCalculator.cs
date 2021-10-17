using System.Collections.Generic;
using System.Linq;

namespace Dgt.Balance
{
    public class PairedIndicesBalancedCalculator : IBalancedCalculator
    {
        private record IndexPair(int StartIndex, int EndIndex)
        {
            public bool Overlaps(IndexPair indexPair) => StartOverlaps(indexPair) || EndOverlaps(indexPair);
            
            private bool StartOverlaps(IndexPair indexPair) => StartIndex >= indexPair.StartIndex && StartIndex <= indexPair.EndIndex;
            
            private bool EndOverlaps(IndexPair indexPair) => EndIndex >= indexPair.StartIndex && EndIndex <= indexPair.EndIndex;
        }
        
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var unpairedIndices = new List<(Delimiter Delimiter, List<int> StartIndices, List<int> EndIndices)>();

            foreach (var delimiter in delimiters)
            {
                var item = IndicesOf(input, delimiter);

                if (item.StartIndices.Count != item.EndIndices.Count) return false;
                
                unpairedIndices.Add(item);
            }

            var pairedIndices = new List<IndexPair>();

            // TODO We don't need the delimiter here, so lets get rid of it!
            foreach (var (_, startIndices, endIndices) in unpairedIndices)
            {
                var (success, item) = PairIndices(startIndices, endIndices);

                if (!success) return false;
                
                pairedIndices.AddRange(item);
            }

            return IndexPairsAreBalanced(pairedIndices);
        }
        
        private static (Delimiter Delimiter, List<int> StartIndices, List<int> EndIndices) IndicesOf(string input, Delimiter delimiter)
        {
            var startIndices = input.IndicesOf(delimiter.Start).ToList();
            var endIndices = input.IndicesOf(delimiter.End).ToList();

            if (delimiter.IsMatchingPair)
            {
                startIndices = startIndices.Where((_, index) => index % 2 == 0).ToList();
                endIndices = endIndices.Where((_, index) => index % 2 == 1).ToList();
            }

            return (delimiter, startIndices, endIndices);
        }
        
        private static (bool Success, List<IndexPair> IndexPairs) PairIndices(IEnumerable<int> startIndices, IEnumerable<int> endIndices)
        {
            var remainingStartIndices = new Queue<int>(startIndices.OrderByDescending(i => i));
            var remainingEndIndices = endIndices.ToList();
            var indexPairs = new List<IndexPair>();

            while (remainingStartIndices.Any())
            {
                var startIndex = remainingStartIndices.Dequeue();
                var endIndex = remainingEndIndices.Find(i => i > startIndex);

                if (endIndex == 0)
                {
                    return (false, new List<IndexPair>());
                }

                indexPairs.Add(new IndexPair(startIndex, endIndex));
                remainingEndIndices.Remove(endIndex);
            }

            return (true, indexPairs);
        }
        
        private static bool IndexPairsAreBalanced(IEnumerable<IndexPair> indexPairs)
        {
            var remaining = indexPairs.ToList();

            while (remaining.Any())
            {
                var toRemove = FindImmediateIndexPairs(remaining).ToList();

                if (!toRemove.Any())
                {
                    return false;
                }
                
                remaining = remaining.Except(toRemove).ToList();
            }

            return true;
        }
        
        private static IEnumerable<IndexPair> FindImmediateIndexPairs(IReadOnlyCollection<IndexPair> indexPairs)
        {
            return indexPairs.Where(first => indexPairs.None(second => first != second && second.Overlaps(first)));
        }
    }
}