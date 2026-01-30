using GarageSpace.EventBus.SDK.Abstractions;
using GarageSpace.EventBus.SDK.Configuration;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GarageSpace.EventBus.SDK.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMassTransitEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EventBusConfiguration>(configuration.GetSection("EventBusConfiguration"));

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    var options = context.GetRequiredService<IOptions<EventBusConfiguration>>().Value;
                    var conn = options.ConnectionString;
                    cfg.Host(conn.Host, conn.Scheme ?? "rabbitmq", h =>
                    {
                        h.Username(conn.Name);
                        h.Password(conn.Password);
                    });
                });
            });

            services.AddScoped<IEventBusPublisher, EventBusPublisher>();

            return services;
        }
    }
}
