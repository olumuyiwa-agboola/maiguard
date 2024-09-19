using Maiguard.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

ServiceConfigurator.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ApplicationConfigurator.ConfigureApp(app);

app.Run();
