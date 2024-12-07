namespace AoC2024.Blazor.Extensions;

public static class StringExtensions
{
    public static IEnumerable<string> SplitLines(this string input)
        => input.Split('\n')
            .Select(x => new string(x.Where(c => c != '\r').ToArray()));
}