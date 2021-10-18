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
    }
}