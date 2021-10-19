using System;

namespace Dgt.Dojo.Optimisations
{
    // Throughout this file (and associated tests and benchmarks) variable names of 'b' and 'n' were chosen to be
    // consistent with mathematical notation
    // See https://en.wikipedia.org/wiki/Exponentiation
    public static class Power
    {
        public static int Baseline(int b, int n)
        {
            return (int)Math.Pow(b, n);
        }

        public static int BitTwiddling(int b, int n)
        {
            var answer = 1;

            while (n > 0)
            {
                var lastBit = n & 1;

                if (lastBit > 0)
                {
                    answer *= b;
                }

                b *= b;
                n >>= 1;
            }

            return answer;
        }
    }
}