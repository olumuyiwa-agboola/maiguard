using Maiguard.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisDistributedCache("maiguard-redis-cache");

ServiceConfigurator.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.MapDefaultEndpoints();

ApplicationConfigurator.ConfigureApp(app);

app.Run();