using System.Collections.Generic;
using Xunit;

namespace Dgt.Balance
{
    public class DelimitedStringsTestData : TheoryData<string, IEnumerable<Delimiter>, bool>
    {
        public DelimitedStringsTestData()
        {
            Add("<elementName>", new[] { Delimiter.AngleBrackets }, true);
            Add("<elementName", new[] { Delimiter.AngleBrackets }, false);
        }
    }
}