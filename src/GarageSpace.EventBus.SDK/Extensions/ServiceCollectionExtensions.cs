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
                    cfg.Host(options.Host, "/", h =>
                    {
                        h.Username(options.Name);
                        h.Password(options.Password);
                    });
                });
            });

            services.AddScoped<IEventBusPublisher, EventBusPublisher>();

            return services;
        }

        public static IServiceCollection AddMassTransitConsumers(this IServiceCollection services, IConfiguration configuration, Action<IRegistrationConfigurator> registerConsumers)
        {
            services.Configure<EventBusConfiguration>(
                configuration.GetSection("EventBusConfiguration"));

            services.AddMassTransit(x =>
            {
                registerConsumers(x);

                x.UsingRabbitMq((context, cfg) =>
                {
                    var options = context
                        .GetRequiredService<IOptions<EventBusConfiguration>>()
                        .Value;

                    cfg.Host(options.Host, "/", h =>
                    {
                        h.Username(options.Name);
                        h.Password(options.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
