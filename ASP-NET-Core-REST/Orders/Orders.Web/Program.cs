using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Orders.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // INFO Ustawienie per œrodowisko i settingsy w appsettings, logowanie do pliku, oraz strukturalne logi pokazano np. w:
            // https://github.com/serilog/serilog/wiki/Configuration-Basics
            // https://jkdev.me/asp-net-core-serilog/
            // https://nblumhardt.com/2019/10/serilog-in-aspnetcore-3/
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
