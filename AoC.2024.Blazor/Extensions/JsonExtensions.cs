using System.Text.Json;
using System.Text.Json.Serialization;

namespace AoC2024.Blazor.Extensions;

public static class JsonExtensions
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public static string ToJson(this object obj)
        => JsonSerializer.Serialize(obj, Options);
    
    public static T? FromJson<T>(this string obj)
        => JsonSerializer.Deserialize<T>(obj, Options);
    
    public static T DeepJsonCopy<T>(this T obj)
        => obj.ToJson().FromJson<T>() ?? throw new InvalidOperationException();
}
