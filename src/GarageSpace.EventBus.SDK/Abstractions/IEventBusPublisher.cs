using GarageSpace.Contracts.Interfaces;

namespace GarageSpace.EventBus.SDK.Abstractions
{
    public interface IEventBusPublisher
    {
        /// <summary>
        /// Publishes a domain or integration event to the message bus.
        /// </summary>
        /// <typeparam name="TMessage">Type of the event.</typeparam>
        /// <param name="event">Event payload.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IEventMessage;

        /// <summary>
        /// Publishes multiple events in a single operation.
        /// Useful for outbox or batch publishing scenarios.
        /// </summary>
        /// <typeparam name="TMessage">Type of the events.</typeparam>
        /// <param name="events">Collection of events.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task PublishBatchAsync<TMessage>(IReadOnlyCollection<TMessage> events, CancellationToken cancellationToken = default) where TMessage : IEventMessage;
    }
}
