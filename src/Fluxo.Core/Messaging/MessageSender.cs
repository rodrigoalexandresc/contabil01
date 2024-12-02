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

        public MessageSender(ILogger<MessageSender> logger)
        {
            _logger = logger;
        }

        public async Task Send<T>(string topicOrQueue, T message)
        {
            var section = _configuration.GetRequiredSection("RabbitMq");

            // Configurações de conexão com o RabbitMQ
            var factory = new ConnectionFactory
            {
                HostName = "localhost", // Endereço do servidor RabbitMQ
                UserName = "guest",     // Usuário padrão
                Password = "guest"      // Senha padrão
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            // Declarar o tópico (exchange)
            //string exchangeName = "my_topic_exchange";
            //channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic);
            await channel.QueueDeclareAsync(topicOrQueue, durable: true);

            // Mensagem a ser enviada
            string routingKey = "lancamento.created"; // Define a chave de roteamento

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            // Publicar a mensagem
            await channel.BasicPublishAsync(topicOrQueue, "lancamento.created", body);

            Console.WriteLine($" [x] Sent '{message}' with Routing Key '{routingKey}'");

            _logger.LogInformation($"Mensagem enviada para tópico {topicOrQueue}: " + message.ToString());
        }
    }
}
