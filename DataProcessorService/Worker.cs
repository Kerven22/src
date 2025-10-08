using DataProcessorService.Abstractions;

namespace DataProcessorService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(
            ILogger<Worker> logger,
            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceScopeFactory.CreateAsyncScope();
                var service =scope.ServiceProvider.GetRequiredService<IGetMessageService>();                 
                await service.GetMessageFromRabbitMQ(stoppingToken); 
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
