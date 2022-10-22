namespace Dgt.Dojo.AddDigits;

public class DigitsAdderTests
{
    [Theory]
    [InlineData(38, 2)]
    [InlineData(1337, 5)]
    [InlineData(987654321, 9)]
    [InlineData(1999999999, 1)]
    [InlineData(int.MaxValue, 1)]
    public void AddDigits_Should_RecursivelyAddDigits(int value, int expected) =>
        DigitsAdder.AddDigits(value).Should().Be(expected);
}