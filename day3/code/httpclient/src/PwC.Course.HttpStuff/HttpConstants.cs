using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace PwC.Course.HttpStuff;

public static class HttpConstants
{
    public static string RandomPersonUrl = "https://webapi.no/api/v1/randomPersons/10";
    public static Uri RandomPersonUri = new(RandomPersonUrl);

    public static JsonSerializerOptions DefaultJsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new JsonStringEnumConverter()
        },
        AllowTrailingCommas = true,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public static T? FromJson<T>(this string s) where T : class
        => JsonSerializer.Deserialize<T>(s, DefaultJsonOptions);

    public static string ToJson<T>(this T s) where T : class? => JsonSerializer.Serialize(s, DefaultJsonOptions); 
}