using FluentAssertions;
using Xunit;

namespace Dgt.Dojo.Optimisations
{
    public class PowerTests
    {
        // We're not bothered by special cases such as base or exponent being zero or negative
        public static TheoryData<int, int, int> PowerTestData => new()
        {
            { 1, 1, 1 },
            { 1, 7, 1 },
            { 2, 2, 4},
            { 2, 8, 256 },
            { 3, 3, 27},
            { 7, 1, 7 },
            { 10, 3, 1000}
        };

        [Theory]
        [MemberData(nameof(PowerTestData))]
        public void Baseline_Should_ReturnBaseRaisedToPower(int b, int n, int expected)
        {
            Power.Baseline(b, n).Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(PowerTestData))]
        public void BitTwiddling_Should_ReturnBaseRaisedToPower(int b, int n, int expected)
        {
            Power.BitTwiddling(b, n).Should().Be(expected);
        }
    }
}