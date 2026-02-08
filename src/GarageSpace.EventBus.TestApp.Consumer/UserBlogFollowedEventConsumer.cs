using GarageSpace.Contracts;
using MassTransit;

namespace GarageSpace.EventBus.TestApp.Consumer
{
    public class UserBlogFollowedEventConsumer : IConsumer<UserBlogFollowedEvent>
    {
        public Task Consume(ConsumeContext<UserBlogFollowedEvent> context)
        {
            Console.WriteLine($"FollowerUser event consumed: {context.Message.FollowerUserId}");
            return Task.CompletedTask;
        }
    }
}
