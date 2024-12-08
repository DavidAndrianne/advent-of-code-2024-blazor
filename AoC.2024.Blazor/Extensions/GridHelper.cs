namespace AoC2024.Blazor.Extensions;

public static class GridHelper
{
    public static char[][] GenerateGrid(int rows, int columns, char value = '.')
    {
        List<char[]> grid = [];
        for (var x = 0; x <= rows; x++)
        {
            var row = new string(value, columns).ToArray();
            grid.Add(row);
        }
        return grid.ToArray();
    }
}