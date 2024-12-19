using System.Text;
using System.Text.RegularExpressions;
using AoC2024.Blazor.Extensions;

namespace AoC2024.Blazor.Parsers.Week4;

public static class Day19Parser
{
    public static (Regex regex, string[] desiredPatterns) ParseAvailableTowelRegexAndDesiredPatterns(this string input)
    {
        var lines = input.SplitLines().ToArray();
        var sb = new StringBuilder();
        foreach(var pattern in  lines.First().Split(", "))
            sb.Append($"{pattern}|");
        Regex regex = new($"^({sb.ToString().Substring(0, sb.Length - 1)})+$");
        
        return (regex, lines.Skip(2).ToArray());
    }
}