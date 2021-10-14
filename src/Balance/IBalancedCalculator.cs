using System.Collections.Generic;

namespace Dgt.Balance
{
    public interface IBalancedCalculator
    {
        bool IsBalanced(string input, IEnumerable<Delimiter> delimiters);
    }
}