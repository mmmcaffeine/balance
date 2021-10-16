namespace Dgt.Balance
{
    public record Delimiter(char Start, char End)
    {
        public static Delimiter Brackets { get; } = new('[', ']');
        public static Delimiter Braces { get; } = new('{', '}');
        public static Delimiter Parentheses { get; } = new('(', ')');
        public static Delimiter AngleBrackets { get; } = new('<', '>');
        public static Delimiter SingleQuotes { get; } = new('\'', '\'');
        public static Delimiter DoubleQuotes { get; } = new('"', '"');

        public override string ToString() => $"{Start}{End}";
        
        public bool IsMatchingPair => Start == End;
        public bool IsOpposingPair => !IsMatchingPair;
    }
}