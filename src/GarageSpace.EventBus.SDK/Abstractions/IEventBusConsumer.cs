using GarageSpace.Contracts.Interfaces;

namespace GarageSpace.EventBus.SDK.Abstractions
{
    public interface IEventBusConsumer<TMessage> where TMessage : IEventMessage
    {
        Task ConsumeAsync(EventMessageContext<IEventMessage> context);
    }
}
