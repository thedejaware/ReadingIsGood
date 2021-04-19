using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RIG.API.Extensions;
using RIG.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace RIG.API
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<RigContext>((context, services) =>
                {
                    var logger = services.GetService<ILogger<RigContextSeed>>();
                    RigContextSeed
                        .SeedAsync(context, logger)
                        .Wait();
                })
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
