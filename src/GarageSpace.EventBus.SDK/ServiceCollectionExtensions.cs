using GarageSpace.EventBus.SDK.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GarageSpace.EventBus.SDK
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers EventBus SDK services.
        /// </summary>
        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            services.AddSingleton<IEventBusPublisher, EventBusPublisher>();

            return services;
        }
    }
}
