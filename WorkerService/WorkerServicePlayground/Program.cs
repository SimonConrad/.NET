using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WorkerServicePlayground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });

        // INFO turning app into a windows service
        //.UseWindowsService();
        // dotnet publish -r win-x64 -c Release
        // To do that, first we need to publish our application.In the project directory we run :
        
        //dotnet publish -r win-x64 -c Release
        //Note in my case, I’m publishing for Windows X64 which generally is going to be the case when deploying a Windows service.
        
        //Then all we need to do is run the standard Windows Service installer.This isn’t.NET Core specific but is instead part of Windows :
        
        //sc create TestService BinPath = C:\full\path\to\publish\dir\WindowsServiceExample.exe
        //As always, the other commands available to you (including starting your service) are :
        
        //sc start TestService
        //sc stop TestService
        //sc delete TestService
    }
}
