using Fluxo.SharedKernel.Bus;
using System.Text;

namespace Fluxo.Consolidacao.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IMessageConsumer _messageConsumer;

        public Worker(ILogger<Worker> logger, IMessageConsumer messageConsumer = null)
        {
            _logger = logger;
            _messageConsumer = messageConsumer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //_messageConsumer.OnMessageReceived += (sender, ea) =>
            //{
            //    var body = ea.Body.ToArray();
            //    var message = Encoding.UTF8.GetString(body);
            //    _logger.LogInformation($"Message received: {message}");
            //};

            _messageConsumer.StartConsuming();

            return Task.CompletedTask;
        }
    }
}
