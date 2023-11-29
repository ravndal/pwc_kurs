using System.Text.Json;

namespace PwC.Course.HttpStuff;

public class HttpBasics
{
    public async Task Run()
    {
        //var task1 = Task.CompletedTask;
        //var task2 = Task.CompletedTask;

        //var tasks = new List<Task> {task1, task2};
        //await Task.WhenAll(tasks);
        //await Task.WhenAny(tasks).ContinueWith(res => res.Result);
        var content = string.Empty;
        using var httpClient = new HttpClient();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = HttpConstants.RandomPersonUri,
        };

        var x = new
        {
            Foo = "bar",
            request.RequestUri,
            Bar = "foobar",
            content
        };

        Console.WriteLine(x.Foo);


        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        content = await response.Content.ReadAsStringAsync();

        var settings = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<RandomPersonResult>(content, settings);
            
        foreach (var item in result.Data)
            Console.WriteLine($"{item.Firstname} {item.Lastname}");
    }
}
