namespace AoC2024.Blazor.Models;

public class FileOnDisk(int id, int size)
{
    public static readonly char Empty = Convert.ToChar(45);
    private const int MagicNumber = 48;
    
    public char Id { get; } = Convert.ToChar(id+MagicNumber);
    public int Size { get; } = size;
    
    public static int IdToInt(char c) => Convert.ToInt32(c-MagicNumber);
}