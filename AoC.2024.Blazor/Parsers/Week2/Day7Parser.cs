using AoC2024.Blazor.Extensions;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using AoC2024.Blazor.Models;

namespace AoC2024.Blazor.Parsers.Week2;

public static class Day7Parser
{
    public static (Direction Direction, int Count)[] ParseMoves(this string input)
        => input.SplitLines()
            .Select(line =>
            {
                var parts = line.Split(" ");
                return (Direction: Direction.Parse(parts[0]), Count: int.Parse(parts[1]));
            })
            .ToArray();
}