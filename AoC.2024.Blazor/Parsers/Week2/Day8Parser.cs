using AoC2024.Blazor.Extensions;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using AoC2024.Blazor.Models;

namespace AoC2024.Blazor.Parsers.Week2;

public static class Day8Parser
{
    public static char[][] ParseCharArray(this string input)
        => input.SplitLines()
            .Select(line => line.ToArray())
            .ToArray();
}