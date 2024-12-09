namespace AoC2024.Blazor.Extensions;

public static class StringExtensions
{
    public static IEnumerable<string> SplitLines(this string input)
        => input.Split('\n')
            .Select(x => new string(x.Where(c => c != '\r').ToArray()));
    
    public static int? FirstIndexOf(this string? input, Func<char, bool> predicate)
        => input?.IndexOf(input.First(predicate));
    
    public static int? LastIndexOf(this string? input, Func<char, bool> predicate)
        => (input?.Length - 1) - new string(input?.Reverse().ToArray()).FirstIndexOf(predicate);

    public static string Swap(this string input, int indexToSwap1, int indexToSwap2)
    {
        var chars = input.ToCharArray();
        (chars[indexToSwap1], chars[indexToSwap2]) = (chars[indexToSwap2], chars[indexToSwap1]);
        return new string(chars);
    }
}