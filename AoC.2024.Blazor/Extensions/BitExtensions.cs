namespace AoC2024.Blazor.Extensions;

public static class BitExtensions
{
    public static string IntToStringFast(this long value, int baseCount = 2)
    {
        char[] representations =
        [
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F'
        ];
        return IntToStringFast(value, representations.Take(baseCount).ToArray());
    }
    
    /// <summary>
    /// An optimized method using an array as buffer instead of 
    /// string concatenation. This is faster for return values having 
    /// a length > 1.
    /// </summary>
    public static string IntToStringFast(this long value, char[] baseChars)
    {
        // 32 is the worst cast buffer size for base 2 and int.MaxValue
        int i = 32;
        char[] buffer = new char[i];
        int targetBase= baseChars.Length;

        do
        {
            buffer[--i] = baseChars[value % targetBase];
            value = value / targetBase;
        }
        while (value > 0);

        char[] result = new char[32 - i];
        Array.Copy(buffer, i, result, 0, 32 - i);

        return new string(result);
    }
}