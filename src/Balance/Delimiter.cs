namespace Dgt.Balance
{
    public record Delimiter(char Start, char End)
    {
        public static Delimiter Brackets { get; } = new('[', ']');
        public static Delimiter Braces { get; } = new('{', '}');
        public static Delimiter Parentheses { get; } = new('(', ')');

        public override string ToString() => $"{Start}{End}";
    }
}