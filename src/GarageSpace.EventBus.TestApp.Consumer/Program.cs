using GarageSpace.EventBus.SDK.Extensions;
using GarageSpace.EventBus.TestApp.Consumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddMassTransitConsumers(builder.Configuration, x =>
{
    x.AddConsumer<UserBlogFollowedEventConsumer>();
});

var host = builder.Build();

Console.WriteLine("Start Consumer Application");

await host.RunAsync();