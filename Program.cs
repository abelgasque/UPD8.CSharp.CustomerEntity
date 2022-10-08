using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog.Events;
using Serilog;
using System.IO;
using System.Net;
using System;

namespace UPD8.CSharp.Customer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("System", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("AplicationName", "UPD8.CSharp.Customer")
                    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
                    .WriteTo.File(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/log.txt"),
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Verbose)
                    .CreateLogger();

                Log.Information("Application - Started");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "Application - Fatal Error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
