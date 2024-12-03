using AoC2024.Blazor.Extensions;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AoC2024.Blazor.Parsers.Week2;

public static class Day3Parser
{
    public static IEnumerable<string> ParseExpression(this string input, string expression)
        => new Regex(expression)
            .Matches(input)
            .Select(x => x.ToString())
            .ToArray();

    public static IEnumerable<int> ParseInts(this string input)
        => new Regex(@"\d+")
            .Matches(input)
                .Select(x => int.Parse(x.ToString()))
                .ToArray();

    public static IEnumerable<string> ParseDoMultitudes(this string input)
    {
        List<string> results = new();
        bool isFirst = true;
        foreach(var part in input.Split("don't()"))
        {
            if (isFirst)
            {
                isFirst = false;
                results.AddRange(part.ParseExpression(@"mul\(\d+,\d+\)"));
                continue;
            }

            var instructions = part.Split("do()");

            var skipped = instructions[0];
            var parsed = string.Join('|', instructions.Skip(1));
            results.AddRange(parsed.ParseExpression(@"mul\(\d+,\d+\)"));
        }

        return results;
    }
}