using System.Text.RegularExpressions;

namespace AoC2024.Blazor.Parsers.Week1;

public static class Day1Parser
{
    public static (int[], int[]) ParseTwoIntColumns(this string input)
    {
        var list = new List<int>();
        var list2 = new List<int>();
        var pattern = new Regex(@"^(\d+)\s+(\d+)$");
        foreach(var line in input.Split("\n"))
            if(pattern.IsMatch(line))
            {
                var matches = pattern.Match(line)
                    .Groups;
                list.Add(int.Parse(matches[1].Value));
                list2.Add(int.Parse(matches[2].Value));
            }
        return (list.ToArray(), list2.ToArray());
    }
}