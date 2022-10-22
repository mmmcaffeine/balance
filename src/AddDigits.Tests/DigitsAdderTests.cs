namespace Dgt.Dojo.AddDigits;

public class DigitsAdderTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(38, 2)]
    [InlineData(1337, 5)]
    [InlineData(987654321, 9)]
    [InlineData(1999999999, 1)]
    [InlineData(int.MaxValue, 1)]
    [InlineData(3999999999, 3)]
    [InlineData(4199999999, 5)]
    [InlineData(uint.MaxValue, 3)]
    public void AddDigitsUsingStringIterationAndRecursion_Should_RecursivelyAddDigits(uint value, byte expected) =>
        DigitsAdder.AddDigitsUsingStringIterationAndRecursion(value).Should().Be(expected);
}