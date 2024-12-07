namespace AoC2024.Blazor.Models;

public class Direction
{
    public static Direction Up = new('U', "Up");
    public static Direction Right = new('R', "Right");
    public static Direction Down = new('D', "Down");
    public static Direction Left = new('L', "Left");

    public static Direction[] All = [Up, Right, Down, Left];
    public static Direction Parse(string s) => Parse(s[0]);
    public static Direction Parse(char c) => All.Single(d => d.Char.Equals(c));
    
    public char Char { get; private set; }
    public string Name { get; private  set; }

    private Direction(char @char, string name)
    {
        Char = @char;
        Name = name;
    }
}