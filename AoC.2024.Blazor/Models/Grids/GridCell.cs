namespace AoC2024.Blazor.Models;

public class GridCell<TVal>(int row, int col, TVal[][] grid) : CarthesianCoordinate(row, col)
{
    public TVal? Value => IsOutsideBounds ? default : grid[Row][Col];
    public TVal[][] Grid => grid;

    public bool IsOutsideBounds => Row < 0 || Col < 0 || Row >= Grid.Length || Col >= Grid.First().Length;
    
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
    
    public GridCell<TVal>[] AdjacentCellsWithinBounds()
    {
        GridCell<TVal>?[] adjacentCells = [AboveCell(), LeftCell(), BelowCell(), RightCell()];
        return adjacentCells.Where(c => c != null)
            .ToArray()!;
    }

    public override CarthesianCoordinate Up => new GridCell<TVal>(Row - 1, Col, Grid);
    public override CarthesianCoordinate Down => new GridCell<TVal>(Row + 1, Col, Grid);
    public override CarthesianCoordinate Left => new GridCell<TVal>(Row, Col - 1, Grid);
    public override CarthesianCoordinate Right => new GridCell<TVal>(Row, Col + 1, Grid);

    public GridCell<TVal>[] AdjacentCells()
    {
        CarthesianCoordinate[] adjacentCells = [Left, Up, Down, Right];
        return adjacentCells.Cast<GridCell<TVal>>().ToArray();
    }

    public override string ToString()
        => $"({Row}, {Col})[{Value}]";
}