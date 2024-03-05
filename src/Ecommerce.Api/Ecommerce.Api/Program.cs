namespace Ecommerce.Api
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The setup of the program prior to startup
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args">Startup args</param>
        /// <returns>Nothing, the host should not stop</returns>
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            try
            {
                await host.StartAsync().ConfigureAwait(false);
                var logger = (ILogger<Program>)host.Services.GetService(typeof(ILogger<Program>));
                logger.LogInformation("Service Started");
            }
            catch (Exception ex)
            {
                var logger = (ILogger<Program>)host.Services.GetService(typeof(ILogger<Program>));
                logger.LogError(ex, "Async Initialization Failure");
                throw;
            }

            host.Run();
        }

        /// <summary>
        /// Create the Host builder
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The WebHost builder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                var configuration = config.Build();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
              .UseStartup<Startup>();
            });
    }
}