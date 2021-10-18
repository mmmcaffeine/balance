using FluentAssertions;
using Xunit;

namespace Dgt.Dojo.FizzBuzz
{
    public class ImplementationsTests
    {
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void ClassicFizzBuzz(int value, string expected)
        {
            Implementations.ClassicFizzBuzz(value).Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void TuplesAndSwitchExpressions(int value, string expected)
        {
            Implementations.TuplesAndSwitchExpressions(value).Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void SwitchExpressionsAndPatternMatching(int value, string expected)
        {
            Implementations.SwitchExpressionsAndPatternMatching(value).Should().Be(expected);
        }
    }
}