using System.Collections.Generic;
using System.Linq;

namespace Dgt.Balance
{
    public class PairedIndicesBalancedCalculator : IBalancedCalculator
    {
        private record IndexPair(int StartIndex, int EndIndex);
        
        // TODO Can we improve performance by short-circuiting some of these loops i.e. there is no point finding all the
        //      indices for the second delimiter if we know the counts for the first are different
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var unpairedIndices = delimiters.Select(delimiter => IndicesOf(input, delimiter)).ToList();

            if (unpairedIndices.Any(x => x.StartIndices.Count != x.EndIndices.Count))
            {
                return false;
            }

            var pairedIndices = unpairedIndices.Select(x => PairIndices(x.StartIndices, x.EndIndices)).ToList();

            if (pairedIndices.Any(x => !x.Success))
            {
                return false;
            }
            
            return IndexPairsAreBalanced(pairedIndices.SelectMany(x => x.IndexPairs));
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
            return indexPairs.Where(first => indexPairs.Except(first).None(second => Overlaps(second, first)));

            bool Overlaps(IndexPair x, IndexPair y) => StartOverlaps(x, y) || EndOverlaps(x, y);

            bool StartOverlaps(IndexPair x, IndexPair y) => x.StartIndex >= y.StartIndex && x.StartIndex <= y.EndIndex;

            bool EndOverlaps(IndexPair x, IndexPair y) => x.EndIndex >= y.StartIndex && x.EndIndex <= y.EndIndex;
        }
    }
}