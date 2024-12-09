using System.Text;
using AoC2024.Blazor.Models;
using AoC2024.Blazor.Parsers.Week2;

namespace AoC2024.Blazor.Parsers.Week3;

public static class Day9Parser
{
    public static IEnumerable<(FileOnDisk File, int EmptySpace)> ParseDiskSpace(this string diskLayout)
    {
        var blocks = diskLayout.ParseDigits()
            .ToArray();
        List<(FileOnDisk File, int EmptySpace)> files = new();
        
        for(var i = 0; (i+1) < blocks.Length; i+=2)
            files.Add((new FileOnDisk(i/2, blocks[i]), blocks[i + 1]));
        if(blocks.Length % 2 == 1) files.Add((new FileOnDisk(blocks.Length/2, blocks.Last()), 0));
        return files;
    }

    public static string ToDiskOverview(this IEnumerable<(FileOnDisk File, int EmptySpace)> files)
    {
        StringBuilder fileSystem = new();
        foreach(var fileWithEmptySpace in files)
            fileSystem.Append(new string(fileWithEmptySpace.File.Id, fileWithEmptySpace.File.Size)+new string(FileOnDisk.Empty, fileWithEmptySpace.EmptySpace));
        return fileSystem.ToString();
    }
}