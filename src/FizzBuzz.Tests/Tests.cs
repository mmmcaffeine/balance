using FluentAssertions;
using Xunit;

namespace Dgt.Dojo.FizzBuzz
{
    // Normally we would have a separate tests file for each type but given every single test is the same, and very short
    // that feels like overkill
    public class Tests
    {
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void A_Baseline(int value, string expected)
        {
            new A_Baseline().FizzBuzz(value).Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void B_TuplesAndSwitchExpressions(int value, string expected)
        {
            new B_TuplesAndSwitchExpressions().FizzBuzz(value).Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void C_SwitchExpressionsAndPatternMatching(int value, string expected)
        {
            new C_SwitchExpressionsAndPatternMatching().FizzBuzz(value).Should().Be(expected);
        }
        
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void D_LookUpAnswerFunction(int value, string expected)
        {
            new D_LookUpAnswerFunction().FizzBuzz(value).Should().Be(expected);
        }
        
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void E_StoreFizzersAndBuzzersInArray(int value, string expected)
        {
            new E_StoreFizzersAndBuzzersInArray().FizzBuzz(value).Should().Be(expected);
        }
        
        [Theory]
        [ClassData(typeof(ClassicTestData))]
        public void F_StoreFizzersAndBuzzersInHashset(int value, string expected)
        {
            new F_StoreFizzersAndBuzzersInHashset().FizzBuzz(value).Should().Be(expected);
        }
    }
}