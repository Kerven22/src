using DataProcessorService.Abstractions;
using DataProcessorService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DataProcessorService.Services
{
    public class GetMessageService(
        IConnectionFactory _connectionFactory,
        IServiceScopeFactory _scopeFactory,
        ILogger<GetMessageService> _logger): IGetMessageService
    {
        public async Task GetMessageFromRabbitMQ(CancellationToken cancellationToken)
        {
            var connection = await _connectionFactory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            string name = "search-engine";
            await channel.QueueDeclareAsync(name, durable: true, exclusive: false, autoDelete: false);
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (s, args) =>
            {
                var message = Encoding.UTF8.GetString(args.Body.ToArray());
                var comments = JsonSerializer.Deserialize<InstrumentStatus>(message);
                using var scope = _scopeFactory.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<ISaveMessageStorage>();
                await service.Executes(comments, cancellationToken);
                await channel.BasicAckAsync(args.DeliveryTag, false);
            };
            await channel.BasicConsumeAsync("search-engine", autoAck: true, consumer: consumer);
        }
    }
}
