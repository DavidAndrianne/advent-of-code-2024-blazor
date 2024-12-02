using System.Text.RegularExpressions;

namespace AoC2024.Blazor.Parsers.Week2;

public static class Day2Parser
{
    public static IEnumerable<IEnumerable<int>> ParseIntLines(this string input)
        => input.Split("\n")
            .Select(x => x.Split(" ").Select(x => int.Parse(x)))
            .ToList();
}