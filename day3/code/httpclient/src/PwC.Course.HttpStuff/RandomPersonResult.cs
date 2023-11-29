using System.Text.Json;

namespace PwC.Course.HttpStuff;

public record RandomPersonResult(List<RandomPersonModel> Data);

public static class RandomPersonExtensions
{
    public static void ParseRandomPersonResult(this string data)
    {
        if (string.IsNullOrEmpty(data))
            return;

        var list = JsonSerializer.Deserialize<RandomPersonResult>(data, HttpConstants.DefaultJsonOptions);

        foreach(var item in list.Data)
            Console.WriteLine($"{item.Firstname} - {item.Lastname}");
    }

    public static void Dump<T>(this T? instance) where T : class
    {
        if (instance == null)
        {
            Console.WriteLine("{ // null }");
            return;

        }
        var json = instance.ToJson();
        Console.WriteLine(json);
    }
}




public class RandomPersonModel
{
    public string Gender { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }

    public void P() => Console.WriteLine($"{Firstname} {Lastname} ({Age})");
}