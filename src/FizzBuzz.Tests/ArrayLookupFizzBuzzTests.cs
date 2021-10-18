using FluentAssertions;
using Xunit;

namespace Dgt.Dojo.FizzBuzz
{
    public class ArrayLookupFizzBuzzTests
    {
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void GetFizzBuzz(int value, string expected)
        {
            ArrayLookupFizzBuzz.GetFizzBuzz(value).Should().Be(expected);
        }
    }
}