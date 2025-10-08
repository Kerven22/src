using FileParserService.Abstraction;
using FileParserService.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;

namespace FileParserService.Service
{
    public class SendMessage : ISendMessage
    {
        private readonly RabbitMQSettings _rabbitmqSettings;

        public SendMessage(IOptions<RabbitMQSettings> options)
        {
            _rabbitmqSettings = options.Value;
        }
        public async Task Send(string message, CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = _rabbitmqSettings.HostName };

            using var connection = await factory.CreateConnectionAsync(cancellationToken);

            using var channel = await connection.CreateChannelAsync();

            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(exchange: _rabbitmqSettings.Exchange,
                routingKey: _rabbitmqSettings.RoutingKey, mandatory: false, body: body);

            Console.WriteLine($"message sended!");
        }
    }
}
