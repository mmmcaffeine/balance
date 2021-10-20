using System;

namespace Dgt.Dojo.Optimisations
{
    public static class IntParse
    {
        public static int Baseline(string value)
        {
            return int.Parse(value);
        }
        
        public static int A_TwoLoopVariables(string value)
        {
            var span = (ReadOnlySpan<char>)value;
            var x = 0;

            for (int i = 0, j = span.Length - 1; i < span.Length; i++, j--)
            {
                x += (span[i] - 48) * Power.BitTwiddling(10, j);
            }

            return x;
        }
        
        public static int B_MathOperations(string value)
        {
            var span = (ReadOnlySpan<char>)value;
            var x = 0;

            for (var i = 0; i < span.Length; i++)
            {
                x += (span[i] - 48) * Power.BitTwiddling(10, span.Length - i - 1);
            }

            return x;
        }

        public static int C_EnumerateBackwardsForPowersOfTen(string value)
        {
            var span = (ReadOnlySpan<char>)value;
            var multiplier = 1;
            var x = 0;
    
            for (var i = span.Length - 1; i >= 0; i--)
            {
                x += (span[i] - 48) * multiplier;
                multiplier *= 10;
            }
    
            return x;
        }
        
        // As C_EnumerateBackwardsForPowersOfTen, but treating the string as a char[] rather than converting it
        // to a ReadOnlySpan<char>. This ends up being about 10% faster than C 😃
        public static int D_NoSpan(string value)
        {
            var multiplier = 1;
            var x = 0;
    
            for (var i = value.Length - 1; i >= 0; i--)
            {
                x += (value[i] - 48) * multiplier;
                multiplier *= 10;
            }
    
            return x;
        }

        // As C_EnumerateBackwardsForPowersOfTen, but having the ReadOnlySpan<char> passed to us, rather than
        // creating it for ourselves. Surprisingly, this is significantly (≈33%) slower than C 😕
        public static int E_InputSpan(ReadOnlySpan<char> value)
        {
            var multiplier = 1;
            var x = 0;
    
            for (var i = value.Length - 1; i >= 0; i--)
            {
                x += (value[i] - 48) * multiplier;
                multiplier *= 10;
            }
    
            return x;
        }
    }
}