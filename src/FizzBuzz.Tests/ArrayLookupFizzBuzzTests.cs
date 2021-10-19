using FluentAssertions;
using Xunit;

namespace Dgt.Dojo.FizzBuzz
{
    public class ArrayLookupFizzBuzzTests
    {
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void GetFizzBuzzFromAnswerFuncs(int value, string expected)
        {
            ArrayLookupFizzBuzz.GetFizzBuzzFromAnswerFuncs(value).Should().Be(expected);
        }
        
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void GetFizzBuzzFromValueArrays(int value, string expected)
        {
            ArrayLookupFizzBuzz.GetFizzBuzzFromValueArrays(value).Should().Be(expected);
        }
        
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void GetFizzBuzzFromValueHashsets(int value, string expected)
        {
            ArrayLookupFizzBuzz.GetFizzBuzzFromValueArrays(value).Should().Be(expected);
        }
    }
}