using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection sc = new ServiceCollection();

            var b = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json");

            var configuration = b.Build();

            sc.AddTransient<IMyService, MyService>();
            sc.AddLogging(c =>
            {
                c.AddConsole();
                c.AddDebug();
            });

            sc.Configure<MyOption>(configuration.GetSection("MyOption"));
            var p = sc.BuildServiceProvider();

            var service = p.GetRequiredService<IMyService>();
            Console.WriteLine(service.Hello());

            Console.ReadLine();
        }
    }
}
