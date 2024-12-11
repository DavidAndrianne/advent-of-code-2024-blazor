using System.Text;
using AoC2024.Blazor.Extensions;
using AoC2024.Blazor.Models;
using AoC2024.Blazor.Parsers.Week2;

namespace AoC2024.Blazor.Parsers.Week3;

public static class Day10Parser
{
    public static int[][] ParseDigitDoubleIntArray(this string input)
        => input.SplitLines()
            .Select(line => line.ParseDigits().ToArray())
            .ToArray();
}