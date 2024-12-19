using System.Text;
using AoC2024.Blazor.Extensions;
using AoC2024.Blazor.Models;
using AoC2024.Blazor.Parsers.Week2;

namespace AoC2024.Blazor.Parsers.Week3;

public static class Day12Parser
{
    public static GridCell<char>[][] ParseCharGrid(this string input)
    {
        var grid = input.ParseCharArray();
        return input.SplitLines()
            .Select((line, row) => line.Select((_, col) => new GridCell<char>(row, col, grid)).ToArray())
            .ToArray();
    }
}