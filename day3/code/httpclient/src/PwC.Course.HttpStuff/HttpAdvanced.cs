using System.ComponentModel.Design;
using System.Text.Json;

namespace PwC.Course.HttpStuff;

public class HttpAdvanced
{
    private readonly IHttpClientFactory _httpClientFactory;
    //private readonly HttpClient _http;

    //public HttpAdvanced(HttpClient http)
    //{   
    //    _http = http;
    //}
    
    public HttpAdvanced(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task Run(string httpEndpoint)
    {
        var http = _httpClientFactory.CreateClient(httpEndpoint);

        var response = await http.GetAsync("/api/v1/randomPersons/10");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        content.ParseRandomPersonResult();
    }

    public async Task RunLinq(string httpEndpoint)
    {
        var http = _httpClientFactory.CreateClient(httpEndpoint);

        var response = await http.GetAsync("/api/v1/randomPersons/1000");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var items = content.FromJson<RandomPersonResult>()!.Data;

        var item = items.FirstOrDefault(p => p.Age == 32);

        // var item2 = items.Single(p => p.Age == 32);

        //Console.WriteLine(items.Count(p=> p.Age < 16));
        //Console.WriteLine(items.Where(p => p.Age < 16).Count());

        var x = items
            .Where(p => p.Age > 20)
            .Where(p => p.Firstname.StartsWith("a", StringComparison.CurrentCultureIgnoreCase));
        
        //foreach(var itemX in items.Where(p=>p.Age == 32))
        //    itemX.Dump();
       
        var list = 
            from foo in items
            where foo.Age > 20
            select foo;

        Console.WriteLine(list.Count());


    }
}
