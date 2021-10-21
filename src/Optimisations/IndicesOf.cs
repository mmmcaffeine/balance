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
        
        public static IEnumerable<int> D_ManualComparisonOfSpansUsingRange(this ReadOnlySpan<char> value, ReadOnlySpan<char> substring)
        {
            var indices = new List<int>();
            var index = 0;
            
            while (index + substring.Length <= value.Length)
            {
                if (Compare(value[index..(index + substring.Length)], substring))
                {
                    indices.Add(index);
                }

                index++;
            }

            return indices;

            bool Compare(ReadOnlySpan<char> left, ReadOnlySpan<char> right)
            {
                if (left.Length != right.Length)
                {
                    return false;
                }
                
                for (var i = 0; i < left.Length; i++)
                {
                    if (left[i] != right[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        
        public static IEnumerable<int> E_ManualComparisonOfSpansUsingOffsetAndLocalFunction(this ReadOnlySpan<char> value, ReadOnlySpan<char> substring)
        {
            var indices = new List<int>();
            var index = 0;
            
            while (index + substring.Length <= value.Length)
            {
                if (Compare(value, substring, index))
                {
                    indices.Add(index);
                }

                index++;
            }

            return indices;

            bool Compare(ReadOnlySpan<char> left, ReadOnlySpan<char> right, int offset)
            {
                for (var i = 0; i < right.Length; i++)
                {
                    if (left[i + offset] != right[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        
        public static IEnumerable<int> F_ManualComparisonOfSpansUsingOffsetAndNestedLoop(this ReadOnlySpan<char> value, ReadOnlySpan<char> substring)
        {
            var indices = new List<int>();
            var index = 0;
            
            while (index + substring.Length <= value.Length)
            {
                for (var j = 0; j < substring.Length; j++)
                {
                    if(value[index + j] != substring[j])
                    {
                        break;
                    }
                    
                    indices.Add(index);
                }

                index++;
            }

            return indices;
        }
    }
}