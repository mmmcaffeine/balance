using Xunit;

namespace Dgt.Balance
{
    public class IsBalancedTestData : TheoryData<string, bool>
    {
        public IsBalancedTestData()
        {
            Add("[]", true);
            Add("{}", true);
            Add("()", true);
            Add("([)]", false);
            Add("([]", false);
            Add("{{)(}}", false);
            Add("({)}", false);
            Add("[({})]", true);
            Add("{}([])", true);
            Add("{()}[[{}]]", true);
        }
    }
}