// See https://aka.ms/new-console-template for more information


using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PwC.Course.HttpStuff;

//var httpBasics = new HttpBasics();
//await httpBasics.Run();

// Configure Serilog
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .WriteTo.Seq("http://localhost:5341/")
//    .CreateLogger();

var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appSettings.json");
var config = configBuilder.Build();

var services = new ServiceCollection()
    .AddLogging(opt =>
    {
        opt.AddConsole();
    })
    .AddSingleton<IConfiguration>(config);

services
    .AddTransient<HttpAdvanced>()
    .AddHttpClient("foo", (serviceProvider, cfg) =>
    {
        var config = serviceProvider.GetRequiredService<IConfiguration>();
        var url = config["url"];
        cfg.BaseAddress = new Uri(url);
    });

var sp = services.BuildServiceProvider();

var httpAdvanced = sp.GetRequiredService<HttpAdvanced>();
//await httpAdvanced.Run("foo");
await httpAdvanced.RunLinq("foo");



Console.WriteLine("done...");