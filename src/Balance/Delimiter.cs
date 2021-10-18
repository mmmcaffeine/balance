using System;

namespace Dgt.Dojo.Balance
{
    public record Delimiter
    {
        public static Delimiter Brackets { get; } = new('[', ']');
        public static Delimiter Braces { get; } = new('{', '}');
        public static Delimiter Parentheses { get; } = new('(', ')');
        public static Delimiter AngleBrackets { get; } = new('<', '>');
        public static Delimiter SingleQuotes { get; } = new('\'', '\'');
        public static Delimiter DoubleQuotes { get; } = new('"', '"');
        public static Delimiter HtmlComment { get; } = new("<!--", "-->");
        public static Delimiter XmlComment { get; } = new("<!--", "-->");
        public static Delimiter RazorComment { get; } = new("@*", "*@");
        public static Delimiter AspxComment { get; } = new("<%--", "--%>");
        public static Delimiter MultiLineComment { get; } = new("/*", "*/");

        public Delimiter(char start, char end)
            : this(start.ToString(), end.ToString())
        {
        }

        public Delimiter(string start, string end)
        {
            Start = start;
            End = end;
        }
        
        public string Start { get; }
        public string End { get; }

        public override string ToString() => $"{Start}{End}";
        
        public bool IsMatchingPair => string.Compare(Start, End, StringComparison.Ordinal) == 0;
        public bool IsOpposingPair => !IsMatchingPair;
    }
}