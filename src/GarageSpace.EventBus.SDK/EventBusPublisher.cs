using GarageSpace.Contracts.Interfaces;
using GarageSpace.EventBus.SDK.Abstractions;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace GarageSpace.EventBus.SDK
{
    internal class EventBusPublisher : IEventBusPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<EventBusPublisher> _logger;

        public EventBusPublisher(IPublishEndpoint publishEndpoint, ILogger<EventBusPublisher> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IEventMessage
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            try
            {
                await _publishEndpoint.Publish(message, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                ex,
                "Failed to publish event. Type: {EventType}",
                typeof(TMessage).Name);

                throw;
            }
        }

        public Task PublishBatchAsync<TMessage>(IReadOnlyCollection<TMessage> events, CancellationToken cancellationToken = default) where TMessage : IEventMessage
        {
            throw new NotImplementedException();
        }
    }
}
