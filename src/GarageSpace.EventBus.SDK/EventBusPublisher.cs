using GarageSpace.Contracts.Interfaces;
using GarageSpace.EventBus.SDK.Abstractions;

namespace GarageSpace.EventBus.SDK
{
    internal class EventBusPublisher : IEventBusPublisher
    {
        public Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IEventMessage
        {
            throw new NotImplementedException();
        }

        public Task PublishBatchAsync<TMessage>(IReadOnlyCollection<TMessage> events, CancellationToken cancellationToken = default) where TMessage : IEventMessage
        {
            throw new NotImplementedException();
        }
    }
}
