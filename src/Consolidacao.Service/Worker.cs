using Consolidacao.Shared;

namespace Consolidacao.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IMessageHandler _messageHandler;

        public Worker(ILogger<Worker> logger, IMessageHandler messageHandler)
        {
            _logger = logger;
            _messageHandler = messageHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {          
            _messageHandler.Handle<>
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    if (_logger.IsEnabled(LogLevel.Information))
            //    {
            //        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    }
            //    await Task.Delay(1000, stoppingToken);
            //}
        }
    }
}
