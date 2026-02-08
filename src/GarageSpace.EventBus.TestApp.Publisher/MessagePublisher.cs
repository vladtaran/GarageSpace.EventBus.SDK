using GarageSpace.Contracts;
using GarageSpace.EventBus.SDK.Abstractions;

namespace GarageSpace.EventBus.TestApp.Publisher
{
    internal class MessagePublisher
    {
        private readonly IEventBusPublisher _publisher;
        public MessagePublisher(IEventBusPublisher publisher) 
        {
            _publisher = publisher;
        }

        public async Task PublishMessage() 
        {
            var msg = new UserBlogFollowedEvent
            {
                FollowerUserId = new Random().Next(1, 100),
                UserId = new Random().Next(1, 10000),
                OccurredAt = DateTime.UtcNow
            };

            try 
            {
                Console.WriteLine($"Publishing message to queue: {msg.FollowerUserId}");

                await _publisher.PublishAsync(msg);

                Console.WriteLine("Message published successfully.");
            }
            catch 
            {
                Console.WriteLine($"Failed to publish message: {msg.FollowerUserId}");

                throw;
            }
        }
    }
}
