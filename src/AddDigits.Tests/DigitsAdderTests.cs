namespace Dgt.Dojo.AddDigits;

public class DigitsAdderTests
{
    public static TheoryData<uint, byte> AddDigitsTestData = new()
    {
        { 0, 0 },
        {38, 2},
        {1337, 5},
        {987654321, 9},
        {1999999999, 1},
        {int.MaxValue, 1},
        {3999999999, 3},
        {4199999999, 5},
        {uint.MaxValue, 3}
    };

    [Theory]
    [MemberData(nameof(AddDigitsTestData))]
    public void AddDigitsUsingStringIterationAndRecursion_Should_RecursivelyAddDigits(uint value, byte expected) =>
        DigitsAdder.AddDigitsUsingStringIterationAndRecursion(value).Should().Be(expected);

    [Theory]
    [MemberData(nameof(AddDigitsTestData))]
    public void AddDigitsUsingOperatorsAndRecursion_Should_RecursivelyAddDigits(uint value, byte expected) =>
        DigitsAdder.AddDigitsUsingOperatorsAndRecursion(value).Should().Be(expected);

    [Theory]
    [MemberData(nameof(AddDigitsTestData))]
    public void AddDigitsUsingDivRemAndRecursion_Should_RecursivelyAddDigits(uint value, byte expected) =>
        DigitsAdder.AddDigitsUsingDivRemAndRecursion(value).Should().Be(expected);
}