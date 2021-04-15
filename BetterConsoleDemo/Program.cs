using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;


// DI, Serilog, settings
namespace BetterConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsetings.json.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
