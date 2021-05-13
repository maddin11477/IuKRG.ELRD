using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace IuKRG.ELRD.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
#if DEBUG
                .WriteTo.Async(c => c.Console())
#endif
                .CreateLogger();

            try
            {
                Log.Information("Starting web host.");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                // Clear existing configuration
                config.Sources.Clear();

                /* Order of precedence is
                    1) appsettings.json file
                    2) appsettings.{ env.EnvironmentName}.json file
                    3) The local User Secrets File #Only in local development environment
                    4) Environment Variables
                    5) Command Line Arguments 
                */

                // Get environment value from launch settings
                var env = hostingContext.HostingEnvironment;
                Log.Information($"Current Hosting Environment : {env.EnvironmentName}");
                // Add json file to ASP.NET Core configuration API
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                // Add Environment Variables
                config.AddEnvironmentVariables();
                
                // Add Command Line Arguments
                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
#region
#if DEBUG
                .UseEnvironment(environment: "Development")
#endif
        #endregion

                .UseAutofac()
                .UseSerilog();
    }
}
