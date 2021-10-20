using System;
using System.Collections.Generic;

namespace Dgt.Dojo.Optimisations
{
    public static class IndicesOf
    {
        public static IEnumerable<int> Baseline(string value, string substring)
        {
            var indices = new List<int>();
            var index = 0;

            while ((index = value.IndexOf(substring, index, StringComparison.Ordinal)) != -1)
            {
                indices.Add(index++);
            }

            return indices;
        }
        
        public static IEnumerable<int> A_YieldReturn(string value, string substring)
        {
            var index = 0;

            while ((index = value.IndexOf(substring, index, StringComparison.Ordinal)) != -1)
            {
                yield return index++;
            }
        }
    }
}