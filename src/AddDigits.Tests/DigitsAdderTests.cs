namespace Dgt.Dojo.AddDigits;

public class DigitsAdderTests
{
    public static TheoryData<IDigitsAdder, uint, byte> AddDigitsTestData
    {
        get
        {
            var theoryData = new TheoryData<IDigitsAdder, uint, byte>();
            var specifications = DigitsAdders.SelectMany(_ => InputsAndOutputs, (sut, io) => (DigitAdder: sut, io.Value, io.Expected));

            foreach (var specification in specifications)
            {
                theoryData.Add(specification.DigitAdder, specification.Value, specification.Expected);
            }

            return theoryData;
        }
    }

    private static IEnumerable<IDigitsAdder> DigitsAdders => typeof(IDigitsAdder).Assembly.GetTypes()
        .Where(x => x.IsAssignableTo(typeof(IDigitsAdder)) && !x.IsAbstract)
        .Select(Activator.CreateInstance)
        .Cast<IDigitsAdder>();

    private static IEnumerable<(uint Value, byte Expected)> InputsAndOutputs => new (uint, byte)[]
    {
        (0, 0),
        (38, 2),
        (1337, 5),
        (987654321, 9),
        (1999999999, 1),
        (int.MaxValue, 1),
        (3999999999, 3),
        (4199999999, 5),
        (uint.MaxValue, 3)
    };

    [Theory]
    [MemberData(nameof(AddDigitsTestData))]
    public void AddDigits_Should_RecursivelyAddDigits(IDigitsAdder sut, uint value, byte expected) =>
        sut.AddDigits(value).Should().Be(expected);
}