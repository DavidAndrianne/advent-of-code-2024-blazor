namespace AoC2024.Blazor.Models;

public class CarthesianCoordinate(int row, int col)
{
    public int Row { get; private set; } = row;
    public int Col { get; private set; } = col;

    public bool IsToTheRight(CarthesianCoordinate coordinate) => Col > coordinate.Col;
    public bool IsToTheLeft(CarthesianCoordinate coordinate) => Col < coordinate.Col;
    
    // Note : as we read line by line, the first row is on top (0)
    // as opposed to a traditional carthesian grid where 0 is on the bottom/middle if negative coordinates are drawn
    public bool IsAbove(CarthesianCoordinate coordinate) => Row < coordinate.Row;
    public bool IsBelow(CarthesianCoordinate coordinate) => Row > coordinate.Row;

    public bool IsMoreThanTwoAwayHorizontally(CarthesianCoordinate coordinate)
        => Math.Abs(Col - coordinate.Col) >= 2;
    
    public bool IsMoreThanTwoAwayVertically(CarthesianCoordinate coordinate)
        => Math.Abs(Row - coordinate.Row) >= 2;

    private static Dictionary<Direction, Action<CarthesianCoordinate>> moves = new()
    {
        { Direction.Up, c => c.MoveUp() },
        { Direction.Down, c => c.MoveDown() },
        { Direction.Left, c => c.MoveLeft() },
        { Direction.Right, c => c.MoveRight() }
    };
    public void Move(Direction direction) => moves[direction].Invoke(this);

    public void MoveUp() => Row--;
    public void MoveDown() => Row++;
    public void MoveLeft() => Col--;
    public void MoveRight() => Col++;
    
    // (2, 1), (3, 2) => (1, 0)
    // (3, 2), (2, 1) => (4, 3)
    // (0, 6), (1, 1) => (-1, 11)
    public CarthesianCoordinate Mirror(CarthesianCoordinate coordinate)
    {
        var row = Row - (coordinate.Row - Row);
        var col = Col - (coordinate.Col - Col);
        return new(row, col);
    }
}