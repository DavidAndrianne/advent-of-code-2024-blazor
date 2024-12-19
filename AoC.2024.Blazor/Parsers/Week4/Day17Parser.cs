using System.Text.RegularExpressions;
using AoC2024.Blazor.Extensions;
using AoC2024.Blazor.Models;
using AoC2024.Blazor.Parsers.Week2;

namespace AoC2024.Blazor.Parsers.Week4;

public static class Day17Parser
{
    public static (Cpu cpu, int[] program) ParseCpuAndProgram(this string input)
    {
        var lines = input.SplitLines().ToArray();
        var cpu = new Cpu(
            lines[0].ParseLongs().First(),
            lines[1].ParseLongs().First(),
            lines[2].ParseLongs().First()
            );
        return (cpu, lines[4].ParseInts().ToArray());
    }
    
    public static IEnumerable<long> ParseLongs(this string input)
        => new Regex(@"\d+")
            .Matches(input)
            .Select(x => long.Parse(x.ToString()))
            .ToArray();
}