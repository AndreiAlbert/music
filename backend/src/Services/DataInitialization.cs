// Services/DataInitializationService.cs
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace src.Services
{
    public class DataInitialization : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DataInitialization(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var jsonDataLoader = scope.ServiceProvider.GetRequiredService<JsonDataLoader>();
                try
                {
                    await jsonDataLoader.LoadJsonData("./data.json");
                    Console.WriteLine("Data loaded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during data loading: {ex.Message}");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Perform any necessary cleanup here
            return Task.CompletedTask;
        }
    }
}