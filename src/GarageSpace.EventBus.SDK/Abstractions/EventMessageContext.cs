using GarageSpace.Contracts.Interfaces;

namespace GarageSpace.EventBus.SDK.Abstractions
{
    public class EventMessageContext<TMessage>(TMessage message) where TMessage : IEventMessage
    {
        public TMessage Message { get; set; } = message;
        public Guid EventId { get; set; }
    }
}
