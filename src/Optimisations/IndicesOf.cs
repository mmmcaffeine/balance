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
        
        public static IEnumerable<int> B_UsingSpanAndList(ReadOnlySpan<char> value, ReadOnlySpan<char> substring)
        {
            var indices = new List<int>();
            var index = 0;
            var lastIndex = -1;
            var remainingValue = value[..];

            while (index < value.Length)
            {
                index = remainingValue.IndexOf(substring, StringComparison.Ordinal);

                if (index == -1)
                {
                    break;
                }
                
                lastIndex = lastIndex + index + 1;
                indices.Add(lastIndex) ;
                remainingValue = remainingValue[(index + 1)..];
            }

            return indices;
        }
        
        public static IEnumerable<int> C_UsingSpanAndStack(ReadOnlySpan<char> value, ReadOnlySpan<char> substring)
        {
            var indices = new Stack<int>();
            var index = 0;
            var lastIndex = -1;
            var remainingValue = value[..];

            while (index < value.Length)
            {
                index = remainingValue.IndexOf(substring, StringComparison.Ordinal);

                if (index == -1)
                {
                    break;
                }

                lastIndex = lastIndex + index + 1;
                indices.Push(lastIndex) ;
                remainingValue = remainingValue[(index + 1)..];
            }

            return indices;
        }
    }
}