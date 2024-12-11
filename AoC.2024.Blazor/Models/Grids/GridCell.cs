namespace AoC2024.Blazor.Models;

public class GridCell<TVal>(int row, int col, TVal[][] grid) : CarthesianCoordinate(row, col)
{
    public TVal Value => grid[Row][Col];
    public TVal[][] Grid => grid;
    
    public GridCell<TVal>? LeftCell()
    {
        var row = Row - 1;
        if (row < 0) return default;
        return new(row, Col, grid);
    }
    
    public GridCell<TVal>? RightCell()
    {
        var row = Row + 1;
        if (row >= grid.Length) return default;
        return new(row, Col, grid);
    }
    
    public GridCell<TVal>? AboveCell()
    {
        var col = Col - 1;
        if (col < 0) return default;
        return new(Row, col, grid);
    }
    
    public GridCell<TVal>? BelowCell()
    {
        var col = Col + 1;
        if (col >= grid.First().Length) return default;
        return new(Row, col, grid);
    }
    
    public GridCell<TVal>[] AdjacentCells()
    {
        GridCell<TVal>?[] adjacentCells = [AboveCell(), LeftCell(), BelowCell(), RightCell()];
        return adjacentCells.Where(c => c != null)
            .ToArray()!;
    }

    public override string ToString()
        => $"({Row}, {Col})[{Value}]";
}