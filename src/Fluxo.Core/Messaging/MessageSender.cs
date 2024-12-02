using Fluxo.SharedKernel.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Fluxo.Core.Messaging
{
    public class MessageSender : IMessageSender
    {
        private readonly ILogger<MessageSender> _logger;
        private readonly IConfiguration _configuration;

        public MessageSender(ILogger<MessageSender> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Send<T>(string topicOrQueue, T message)
        {
            var rabbitMqConfiguration = _configuration.GetRequiredSection("RabbitMq");

            // Configurações de conexão com o RabbitMQ
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(rabbitMqConfiguration["Connection"].ToString());
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(topicOrQueue, durable: true, exclusive: false, autoDelete: false);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);          

            await channel.BasicPublishAsync(
                exchange: null,  
                routingKey: topicOrQueue, 
                body);

            Console.WriteLine($" [x] Sent '{message}' with Routing Key '{topicOrQueue}'");

            _logger.LogInformation($"Mensagem enviada para tópico {topicOrQueue}: " + message.ToString());
        }
    }
}
