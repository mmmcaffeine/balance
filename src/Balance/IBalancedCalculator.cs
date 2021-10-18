using System.Collections.Generic;

namespace Dgt.Dojo.Balance
{
    public interface IBalancedCalculator
    {
        bool IsBalanced(string input, IEnumerable<Delimiter> delimiters);
    }
}