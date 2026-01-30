using Microsoft.Extensions.Hosting;
using GarageSpace.EventBus.SDK.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransitEventBus(builder.Configuration);

var host = builder.Build();
host.Run();