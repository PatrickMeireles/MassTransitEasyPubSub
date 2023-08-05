using MassTransit;
using MassTransitPublisher.Api.Model;

namespace MassTransitPublisher.Api.Worker.Consumer
{
    public class PersonCreateConsumer : IConsumer<PersonCreateMessage>
    {
        private readonly ILogger<PersonCreateConsumer> _logger;

        public PersonCreateConsumer(ILogger<PersonCreateConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PersonCreateMessage> context)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation("Received Message");
            });
        }
    }
}
