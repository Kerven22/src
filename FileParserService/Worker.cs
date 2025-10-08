using FileParserService.Abstraction;

namespace FileParserService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISendMessage _sendMessage; 
        private readonly ISerializerService _serializerService;

        public Worker(ILogger<Worker> logger, 
            ISerializerService serializerService, 
            ISendMessage sendMessage)
        {
            _logger = logger;
            _serializerService = serializerService;
            _sendMessage = sendMessage;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = await _serializerService.Serialize("C:/Users/kerve/Desktop/DockerWork/statuses.xml");
                await _sendMessage.Send(message, stoppingToken); 

                //if (_logger.IsEnabled(LogLevel.Information))
                //{
                //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //}
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
