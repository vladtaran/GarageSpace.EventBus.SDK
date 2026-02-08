using GarageSpace.EventBus.SDK.Abstractions;
using GarageSpace.EventBus.SDK.Extensions;
using GarageSpace.EventBus.TestApp.Publisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddMassTransitEventBus(builder.Configuration);

var host = builder.Build();

Console.WriteLine("Start Publisher Application");

using var scope = host.Services.CreateScope();
IEventBusPublisher publisher = scope.ServiceProvider.GetRequiredService<IEventBusPublisher>();

var msgPublisher = new MessagePublisher(publisher);

await msgPublisher.PublishMessage();

await host.RunAsync();