var builder = DistributedApplication.CreateBuilder(args);

var maiguardRedisCache = builder.AddRedis("maiguard-redis-cache")
    .WithRedisCommander();

builder.AddProject<Projects.Maiguard_API>("maiguard-api")
    .WithExternalHttpEndpoints().WithReference(maiguardRedisCache);

builder.Build().Run();